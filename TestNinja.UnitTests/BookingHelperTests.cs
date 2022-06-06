
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExistsTests
    {
        private Mock<IBookingRepository> _mockBookingRepository;

        [SetUp]
        public void SetUp()
        {
            _mockBookingRepository = new Mock<IBookingRepository>();
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            _mockBookingRepository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2017, 1, 15, 14, 0, 0),
                    DepartureDate = new DateTime(2017, 1, 20, 10, 0 , 0),
                    Reference = "a"
                }
            }.AsQueryable());

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2017, 1, 10, 14, 0, 0),
                DepartureDate = new DateTime(2017, 1, 14, 10, 0, 0),
            }, _mockBookingRepository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingFinishesDuringAnExsitingBooking_ReturnExistingBookingReference()
        {

        }

        [Test]
        public void BookingStartsDuringAndFinishesAfterAnExsitingBooking_ReturnExistingBookingReference()
        {

        }
    }
}
