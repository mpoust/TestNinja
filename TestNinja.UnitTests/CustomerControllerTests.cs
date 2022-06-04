
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {

        private CustomerController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            // Act
            var result = _controller.GetCustomer(0);

            // Assert
            // Explicitly a NotFound object
            Assert.That(result, Is.TypeOf<NotFound>());

            // NotFound or one of its derivatives
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetCustomer_IdIsNotZero_ReturnOk(int custNum)
        {
            // Act
            var result = _controller.GetCustomer(custNum);

            // Assert
            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
