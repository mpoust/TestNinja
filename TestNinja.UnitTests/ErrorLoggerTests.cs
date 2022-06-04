using NUnit.Framework;
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
    }
}
