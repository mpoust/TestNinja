
using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void CalculateDemeritPoints_SpeedIsNegative_ThrowsArgumentOutOfRangeException(int speed)
        {
            // Act & Assert to test exception
            Assert.That(() => _calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(305)]
        [TestCase(450)]
        public void CalculateDemeritPoints_SpeedIsOver300_ThrowsArgumentOutOfRangeException(int speed)
        {
            // Act & Assert to test exception
            Assert.That(() => _calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturDemeritPoints(int speed, int expectedResult)
        {
            // Act
            var result = _calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
