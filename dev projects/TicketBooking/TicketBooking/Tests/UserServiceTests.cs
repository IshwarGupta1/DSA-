using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using TicketBooking.Models;
using TicketBooking.Service;

namespace TicketBooking.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private DataContext _dataContext;
        private ISeatService _seatService;
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _dataContext = Substitute.For<DataContext>();
            _seatService = Substitute.For<ISeatService>();
            _userService = new UserService(_dataContext, _seatService);
        }

        [Test]
        public async Task GetAvailableEvents_ShouldReturnEventsWithAvailableSeats()
        {
            // Arrange
            var events = new List<Event>
            {
                new Event { Id = 1, Seats = new List<Seat> { new Seat { isAvailable = true } } },
                new Event { Id = 2, Seats = new List<Seat> { new Seat { isAvailable = false } } }
            };
            _dataContext.events.Where(e => e.Seats.Any(s => s.isAvailable)).Returns(events.Where(e => e.Seats.Any(s => s.isAvailable)).ToList());

            // Act
            var result = await _userService.GetAvailableEvents();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].Id);
        }

        [Test]
        public async Task IsSeatAvailableForEvent_ShouldReturnTrue_WhenSeatIsAvailable()
        {
            // Arrange
            var seat = new Seat { isAvailable = true };
            var eventId = 1;
            var seatId = 1;
            _seatService.IsSeatAvailableForEvent(seatId, eventId).Returns(true);

            // Act
            var result = await _userService.IsSeatAvailableForEvent(seatId, eventId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsSeatAvailableForEvent_ShouldReturnFalse_WhenSeatIsNotAvailable()
        {
            // Arrange
            var seat = new Seat { isAvailable = false };
            var eventId = 1;
            var seatId = 1;
            _seatService.IsSeatAvailableForEvent(seatId, eventId).Returns(false);

            // Act
            var result = await _userService.IsSeatAvailableForEvent(seatId, eventId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task BookSeat_ShouldReturnBookingResponse_WhenSeatIsAvailable()
        {
            // Arrange
            var userId = 1;
            var eventId = 1;
            var bookingResponse = new BookingResponse { bookingId = 1, bookingTime = DateTime.Now, seatId = 1 };
            _seatService.BookSeat(userId, eventId).Returns(bookingResponse);

            // Act
            var result = await _userService.bookSeat(userId, eventId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.bookingId);
        }

        [Test]
        public async Task BookSeatByCategory_ShouldReturnBookingResponse_WhenSeatIsAvailable()
        {
            // Arrange
            var userId = 1;
            var eventId = 1;
            var seatType = SeatType.Regular;
            var bookingResponse = new BookingResponse { bookingId = 1, bookingTime = DateTime.Now, seatId = 1 };
            _seatService.BookSeatByCategory(userId, eventId, seatType).Returns(bookingResponse);

            // Act
            var result = await _userService.bookSeatByCategory(userId, eventId, seatType);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.bookingId);
        }

        [Test]
        public void CancelBooking_ShouldThrowArgumentNullException_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 1;
            var bookingId = 1;
            _dataContext.user.FirstOrDefault(u => u.userId == userId).Returns((User)null);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _userService.CancelBooking(userId, bookingId));
        }

        [Test]
        public void CancelBooking_ShouldThrowArgumentException_WhenBookingDoesNotExist()
        {
            // Arrange
            var userId = 1;
            var bookingId = 1;
            var user = new User { userId = userId, bookings = new List<Booking>() };
            _dataContext.user.FirstOrDefault(u => u.userId == userId).Returns(user);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _userService.CancelBooking(userId, bookingId));
        }

        [Test]
        public async Task CancelBooking_ShouldCancelBookingSuccessfully_WhenBookingExists()
        {
            // Arrange
            var userId = 1;
            var bookingId = 1;
            var user = new User { userId = userId, bookings = new List<Booking> { new Booking { Id = bookingId } } };
            var reqEvent = new Event { Id = 1, Seats = new List<Seat> { new Seat { Id = 1, isAvailable = false } } };
            _dataContext.user.FirstOrDefault(u => u.userId == userId).Returns(user);
            _dataContext.events.FirstOrDefault(e => e.Id == 1).Returns(reqEvent);

            // Act
            await _userService.CancelBooking(userId, bookingId);

            // Assert
            Assert.IsTrue(reqEvent.Seats[0].isAvailable);
        }

        [Test]
        public void ListAllBookings_ShouldThrowArgumentNullException_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 1;
            _dataContext.user.FirstOrDefault(u => u.userId == userId).Returns((User)null);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _userService.listAllBookings(userId));
        }

        [Test]
        public async Task ListAllBookings_ShouldReturnBookings_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var user = new User { userId = userId, bookings = new List<Booking> { new Booking { Id = 1 } } };
            _dataContext.user.FirstOrDefault(u => u.userId == userId).Returns(user);

            // Act
            var result = await _userService.listAllBookings(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }
    }
}
