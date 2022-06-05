using NUnit.Framework;
using TestNinja.Mocking;
using TestNinja.UnitTests.Mocks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var service = new VideoService();

            var result = service.ReadVideoTitle(new MockFileReader());

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
