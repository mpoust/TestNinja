

using System.Net;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class InstallerHelperTests
    {

        private Mock<IFileDownloader> _mockFileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _mockFileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_mockFileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            //_mockFileDownloader.Setup(fd => fd.DownloadFile("http://example.com/customer/installer", null)).Throws<WebException>();

            // more generic method to achieve the same thing as above, preventing requiring to send the exact string expected in its implementation
            _mockFileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }
    }
}
