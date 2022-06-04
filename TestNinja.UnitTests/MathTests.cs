using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            // Act
            var result = _math.Add(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            // Act
            var result = _math.Max(2, 1);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            // Act
            var result = _math.Max(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(2));

        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            // Act
            var result = _math.Max(2, 2);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }
    }
}
