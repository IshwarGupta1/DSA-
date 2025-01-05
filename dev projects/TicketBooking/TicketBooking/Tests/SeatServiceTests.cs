using NUnit.Framework;
using NSubstitute;
using TicketBooking.Models;
using TicketBooking.Service;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketBooking.Tests
{
    [TestFixture]
    public class SeatServiceTests
    {
        private ISeatService _seatService;
        private DataContext _dataContextMock;

        [SetUp]
        public void Setup()
        {
            _dataContextMock = Substitute.For<DataContext>();
            _seatService = new SeatService(_dataContextMock);
        }

        [Test]
        public async Task BookSeat_WhenEventDoesNotExist_ThrowsArgumentNullException()
        {
            // Arrange
            var eventId = 1;
            var userId = 1;
            _dataContextMock.events.FirstOrDefault(Arg.Any<Func<Event, bool>>()).Returns((Event)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _seatService.BookSeat(eventId, userId));
            Assert.That(ex.Message, Is.EqualTo("event does not exist"));
        }

        [Test]
        public async Task BookSeat_WhenNoAvailableSeats_ThrowsException()
        {
            // Arrange
            var eventId = 1;
            var userId = 1;
            var mockEvent = new Event
            {
                Id = eventId,
                Seats = new List<Seat> { new Seat { isAvailable = false } }
            };
            _dataContextMock.events.FirstOrDefault(Arg.Any<Func<Event, bool>>()).Returns(mockEvent);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _seatService.BookSeat(eventId, userId));
            Assert.That(ex.Message, Is.EqualTo("no seats available"));
        }

        [Test]
        public async Task BookSeat_WhenBookingIsSuccessful_ReturnsBookingResponse()
        {
            // Arrange
            var eventId = 1;
            var userId = 1;
            var mockEvent = new Event
            {
                Id = eventId,
                Seats = new List<Seat> { new Seat { Id = 1, isAvailable = true, seatNum = 1 } }
            };
            _dataContextMock.events.FirstOrDefault(Arg.Any<Func<Event, bool>>()).Returns(mockEvent);
            var mockUser = new User { userId = userId, bookings = new List<Booking>() };
            _dataContextMock.user.FirstOrDefault(Arg.Any<Func<User, bool>>()).Returns(mockUser);

            _dataContextMock.AddAsync(Arg.Any<Booking>()).Returns(Task.CompletedTask);
            _dataContextMock.SaveChangesAsync().Returns(Task.CompletedTask);

            // Act
            var response = await _seatService.BookSeat(eventId, userId);

            // Assert
            Assert.Equals(response.bookingId, 1);  // Assuming new booking ID is 1
            Assert.Equals(response.seatId, 1);
            Assert.Equals(response.bookingTime.Date, DateTime.Now.Date);  // Compare only the date part
        }

        [Test]
        public async Task BookSeatByCategory_WhenEventDoesNotExist_ThrowsArgumentNullException()
        {
            // Arrange
            var eventId = 1;
            var userId = 1;
            var category = SeatType.VIP;
            _dataContextMock.events.FirstOrDefault(Arg.Any<Func<Event, bool>>()).Returns((Event)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _seatService.BookSeatByCategory(eventId, userId, category));
            Assert.That(ex.Message, Is.EqualTo("event does not exist"));
        }

        [Test]
        public async Task BookSeatByCategory_WhenNoAvailableSeats_ThrowsException()
        {
            // Arrange
            var eventId = 1;
            var userId = 1;
            var category = SeatType.VIP;
            var mockEvent = new Event
            {
                Id = eventId,
                Seats = new List<Seat> { new Seat { isAvailable = false, seatType = category } }
            };
            _dataContextMock.events.FirstOrDefault(Arg.Any<Func<Event, bool>>()).Returns(mockEvent);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _seatService.BookSeatByCategory(eventId, userId, category));
            Assert.That(ex.Message, Is.EqualTo("no seats available"));
        }

        [Test]
        public async Task BookSeatByCategory_WhenBookingIsSuccessful_ReturnsBookingResponse()
        {
            // Arrange
            var eventId = 1;
            var userId = 1;
            var category = SeatType.VIP;
            var mockEvent = new Event
            {
                Id = eventId,
                Seats = new List<Seat> { new Seat { Id = 1, isAvailable = true, seatNum = 1, seatType = category } }
            };
            _dataContextMock.events.FirstOrDefault(Arg.Any<Func<Event, bool>>()).Returns(mockEvent);
            var mockUser = new User { userId = userId, bookings = new List<Booking>() };
            _dataContextMock.user.FirstOrDefault(Arg.Any<Func<User, bool>>()).Returns(mockUser);

            _dataContextMock.AddAsync(Arg.Any<Booking>()).Returns(Task.CompletedTask);
            _dataContextMock.SaveChangesAsync().Returns(Task.CompletedTask);

            // Act
            var response = await _seatService.BookSeatByCategory(eventId, userId, category);

            // Assert
            Assert.Equals(response.bookingId, 1);
            Assert.Equals(response.seatId, 1);
            Assert.Equals(response.bookingTime.Date, DateTime.Now.Date);
        }

        [Test]
        public async Task IsSeatAvailableForEvent_WhenEventDoesNotExist_ThrowsArgumentNullException()
        {
            // Arrange
            var seatId = 1;
            var eventId = 1;
            _dataContextMock.events.FirstOrDefault(Arg.Any<Func<Event, bool>>()).Returns((Event)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _seatService.IsSeatAvailableForEvent(seatId, eventId));
            Assert.That(ex.Message, Is.EqualTo("event does not exist"));
        }

        [Test]
        public async Task IsSeatAvailableForEvent_WhenSeatIsNotPartOfEvent_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var seatId = 1;
            var eventId = 1;
            var mockEvent = new Event
            {
                Id = eventId,
                Seats = new List<Seat> { new Seat { Id = 2, isAvailable = true, seatNum = 1 } }
            };
            _dataContextMock.events.FirstOrDefault(Arg.Any<Func<Event, bool>>()).Returns(mockEvent);
            _dataContextMock.seat.FirstOrDefault(Arg.Any<Func<Seat, bool>>()).Returns(new Seat { Id = seatId });

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _seatService.IsSeatAvailableForEvent(seatId, eventId));
            Assert.That(ex.Message, Is.EqualTo("seat is not of this event"));
        }

        [Test]
        public async Task IsSeatAvailableForEvent_WhenSeatIsAvailable_ReturnsTrue()
        {
            // Arrange
            var seatId = 1;
            var eventId = 1;
            var mockEvent = new Event
            {
                Id = eventId,
                Seats = new List<Seat> { new Seat { Id = seatId, isAvailable = true, seatNum = 1 } }
            };
            _dataContextMock.events.FirstOrDefault(Arg.Any<Func<Event, bool>>()).Returns(mockEvent);
            _dataContextMock.seat.FirstOrDefault(Arg.Any<Func<Seat, bool>>()).Returns(mockEvent.Seats.First());

            // Act
            var result = await _seatService.IsSeatAvailableForEvent(seatId, eventId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsSeatAvailableForEvent_WhenSeatIsNotAvailable_ReturnsFalse()
        {
            // Arrange
            var seatId = 1;
            var eventId = 1;
            var mockEvent = new Event
            {
                Id = eventId,
                Seats = new List<Seat> { new Seat { Id = seatId, isAvailable = false, seatNum = 1 } }
            };
            _dataContextMock.events.FirstOrDefault(Arg.Any<Func<Event, bool>>()).Returns(mockEvent);
            _dataContextMock.seat.FirstOrDefault(Arg.Any<Func<Seat, bool>>()).Returns(mockEvent.Seats.First());

            // Act
            var result = await _seatService.IsSeatAvailableForEvent(seatId, eventId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
