

using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            // Act & Assert for exception test
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArgument_AddObjectToTheStack()
        {
            _stack.Push("ABC");

            Assert.That(_stack.Count, Is.EqualTo(1));

            _stack.Push("XYZ");

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            // Act & Assert for exception test
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithAFewObjects_ReturnsObjectOnTheTop()
        {
            // Arrange
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");

            // Act
            var result = _stack.Pop();

            // Assert
            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void Pop_StackWithAFewObjects_RemoveObjectOnTheTop()
        {
            // Arrange
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");

            // Act
            _stack.Pop();

            // Assert
            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowsInvalidOperationException()
        {
            // Act & Assert for exception test
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithAFewObjects_ReturnsObjectOnTheTop()
        {
            // Arrange
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");

            // Act
            var result = _stack.Peek();

            // Assert
            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void Peek_StackWithAFewObjects_DoesNotRemoveObjectOnTheTop()
        {
            // Arrange
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");

            // Act
            _stack.Peek();

            // Assert
            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}
