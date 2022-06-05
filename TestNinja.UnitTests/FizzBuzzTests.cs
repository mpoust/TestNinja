
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {

        [Test]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        public static void GetOutput_DivisibleOnlyByThree_ReturnsFizz(int i)
        {
            // Act
            var result = FizzBuzz.GetOutput(i);

            // Assert
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(25)]
        public void GetOutput_DivisibleOnlyByFive_ReturnsBuzz(int i)
        {
            // Act
            var result = FizzBuzz.GetOutput(i);

            // Assert
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(60)]
        public void GetOutput_DivisibleByThreeAndFive_ReturnsFizzBuzz(int i)
        {
            // Act
            var result = FizzBuzz.GetOutput(i);

            // Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(7)]
        public void GetOutput_NotDivisibleByThreeOrFive_ReturnsNumber(int i)
        {
            // Act
            var result = FizzBuzz.GetOutput(i);

            // Assert
            Assert.That(result, Is.EqualTo(i.ToString()));
        }
    }
}
