using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Hotel.Domain.Entities;
using Hotel.Domain.DomainServices;
using Hotel.Domain.Contracts.Repositories;
using Hotel.Domain.Contracts.DomainServices;

namespace Hotel.Tests.DomainServices
{
    public class BookingDomainServiceTests
    {
        private readonly Mock<IBookingRepository> _bookingRepositoryMock;
        private readonly Mock<IRoomRepository> _roomRepositoryMock;
        private readonly BookingDomainService _bookingDomainService;

        public BookingDomainServiceTests()
        {
            _bookingRepositoryMock = new Mock<IBookingRepository>();
            _roomRepositoryMock = new Mock<IRoomRepository>();
            _bookingDomainService = new BookingDomainService(_bookingRepositoryMock.Object, _roomRepositoryMock.Object);
        }

        [Fact]
        public async Task RegisterAsync_ShouldCreateBooking_WhenBookingIsValid()
        {
            // Arrange
            var booking = new Booking
            {
                CheckinDate = DateTime.Today.AddDays(1),
                CheckoutDate = DateTime.Today.AddDays(2),
                RoomID = Guid.NewGuid(),
            };

            var room = new Room
            {
                IsAvailable = true,
                DailyRate = 100,
            };

            _roomRepositoryMock.Setup(r => r.GetByIDAsync(booking.RoomID)).ReturnsAsync(room);
            _bookingRepositoryMock.Setup(b => b.InsertAsync(booking)).ReturnsAsync(true);
            _roomRepositoryMock.Setup(r => r.UpdateAsync(room)).ReturnsAsync(true);

            // Act
            var result = await _bookingDomainService.RegisterAsync(booking);

            // Assert
            Assert.True(result);
            Assert.Equal(100, booking.TotalCost);
            Assert.False(room.IsAvailable);
            Assert.Equal(DateTime.Today.AddDays(2), room.NextBookingAvailableDate);

            _roomRepositoryMock.Verify(r => r.GetByIDAsync(booking.RoomID), Times.Once);
            _bookingRepositoryMock.Verify(b => b.InsertAsync(booking), Times.Once);
            _roomRepositoryMock.Verify(r => r.UpdateAsync(room), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateBookingAndRoom_WhenInputIsValid()
        {
            // Arrange
            var booking = new Booking
            {
                BookingID = Guid.NewGuid(),
                RoomID = Guid.NewGuid(),
                CheckinDate = DateTime.Today.AddDays(2),
                CheckoutDate = DateTime.Today.AddDays(4)
            };

            var room = new Room
            {
                RoomID = booking.RoomID,
                IsAvailable = true,
                DailyRate = 100,
                NextBookingAvailableDate = booking.CheckinDate.AddDays(-1)
            };

            _roomRepositoryMock.Setup(x => x.GetByIDAsync(booking.RoomID)).ReturnsAsync(room);
            _bookingRepositoryMock.Setup(x => x.UpdateAsync(booking)).ReturnsAsync(true);
            _roomRepositoryMock.Setup(x => x.UpdateAsync(room)).ReturnsAsync(true);

            // Act
            var result = await _bookingDomainService.UpdateAsync(booking);

            // Assert
            Assert.True(result);
            Assert.Equal(2 * room.DailyRate, booking.TotalCost);
            Assert.False(room.IsAvailable);
            Assert.Equal(booking.CheckoutDate, room.NextBookingAvailableDate);
            _bookingRepositoryMock.Verify(x => x.UpdateAsync(booking), Times.Once);
            _roomRepositoryMock.Verify(x => x.UpdateAsync(room), Times.Once);
        }
    }
}