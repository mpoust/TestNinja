using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }

        [Test]
        [TestCase("Error Test Message")]
        public void Log_WhenCalled_SetTheLastErrorProperty(string logMessage)
        {
            // Act
            _logger.Log(logMessage);

            // Assert
            Assert.That(_logger.LastError, Is.EqualTo(logMessage));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string logMessage)
        {
            // Act & Assert - because of throwing an exception 
            Assert.That(() => _logger.Log(logMessage), Throws.ArgumentNullException);

            // As another example you can assert by the type
           // Assert.That(() => _logger.Log(logMessage), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            // Act - subscribe to the event
            var id = Guid.Empty;
            _logger.ErrorLogged += (sender, args) => { id = args; };

            _logger.Log("Test Error");

            // Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
