
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private OrderService _orderService;
        private Mock<IStorage> _mockStorage;

        [SetUp]
        public void SetUp()
        {
            _mockStorage = new Mock<IStorage>();
            _orderService = new OrderService(_mockStorage.Object);
        }


        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var order = new Order();
            var result = _orderService.PlaceOrder(order);

            _mockStorage.Verify(s => s.Store(order));
        }
    }
}
