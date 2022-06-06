using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;

        private Mock<IVideoRepository> _mockVideoRepository;
        private Mock<IFileReader> _mockFileReader;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockVideoRepository = new Mock<IVideoRepository>();

            _videoService = new VideoService(_mockFileReader.Object, _mockVideoRepository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var service = new VideoService(_mockFileReader.Object);

            var result = service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _mockVideoRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnStringWithIdOfUnprocessedVideos()
        {
            _mockVideoRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video { Id = 1 },
                new Video { Id = 2 },
                new Video { Id = 3 }
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
