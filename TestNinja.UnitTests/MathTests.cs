using NUnit.Framework;
using System.Linq;
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
        [Ignore("Show how to temporarily disable and ignore test cases")]
        public void Add_ExampleIgnoredTest_TestIsIgnored()
        {
            // Act
            var result = _math.Add(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(1, 2, 3)]
        public void Add_WhenCalled_ReturnTheSumOfArguments(int a, int b, int expectedResult)
        {
            // Act
            var result = _math.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            // Act
            var result = _math.Max(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            // Act
            var result = _math.GetOddNumbers(5);

            // Assert
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(3));

            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));

            // Same way as writing the above three lines
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            // Couple more useful assertions

            // that the result is sorted
            Assert.That(result, Is.Ordered);
            // that the array has no duplicate items
            Assert.That(result, Is.Unique);
        }
    }
}
