
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _controller;
        private Mock<IEmployeeService> _mockEmployeeService;

        [SetUp]
        public void SetUp()
        {
            _mockEmployeeService = new Mock<IEmployeeService>();
            _controller = new EmployeeController(_mockEmployeeService.Object);
        }

        [Test]
        [TestCase(1)]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb(int id)
        {
            _controller.DeleteEmployee(id);

            _mockEmployeeService.Verify(s => s.DeleteEmployee(id));
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnsRedirectResult()
        {
            var result = _controller.DeleteEmployee(1);

            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}
