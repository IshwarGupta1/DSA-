using NUnit.Framework;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Models;
using TicketBooking.Service;

namespace TicketBooking.Tests
{
    [TestFixture]
    public class AdminServiceTests
    {
        private AdminService _adminService;
        private DataContext _dataContextMock;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _dataContextMock = new DataContext(options);
            _adminService = new AdminService(_dataContextMock);
        }

        [Test]
        public async Task CreateEvent_ValidEvent_ReturnsCreatedEvent()
        {
            // Arrange
            var newEvent = new Event { Id = 1, Name = "Test Event", EventDate = DateTime.Now, Seats = new List<Seat>() };

            // Act
            var createdEvent = await _adminService.CreateEvent(newEvent);

            // Assert
            Assert.Equals(newEvent.Name, createdEvent.Name);
        }

        [Test]
        public async Task GetEventById_ValidId_ReturnsEvent()
        {
            // Arrange
            var newEvent = new Event { Id = 1, Name = "Test Event", EventDate = DateTime.Now, Seats = new List<Seat>() };
            await _dataContextMock.events.AddAsync(newEvent);
            await _dataContextMock.SaveChangesAsync();

            // Act
            var fetchedEvent = await _adminService.GetEventById(1);

            // Assert
            Assert.Equals(newEvent.Name, fetchedEvent.Name);
        }

        [Test]
        public void GetEventById_InvalidId_ThrowsKeyNotFoundException()
        {
            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _adminService.GetEventById(99));
        }

        [Test]
        public async Task GetAllEvents_ReturnsAllEvents()
        {
            // Arrange
            var events = new List<Event>
            {
                new Event { Id = 1, Name = "Event 1", EventDate = DateTime.Now, Seats = new List<Seat>() },
                new Event { Id = 2, Name = "Event 2", EventDate = DateTime.Now, Seats = new List<Seat>() }
            };
            await _dataContextMock.events.AddRangeAsync(events);
            await _dataContextMock.SaveChangesAsync();

            // Act
            var fetchedEvents = await _adminService.GetAllEvents();

            // Assert
            Assert.Equals(2, fetchedEvents.ToList().Count);
        }

        [Test]
        public async Task UpdateEvent_ValidId_ReturnsUpdatedEvent()
        {
            // Arrange
            var newEvent = new Event { Id = 1, Name = "Old Event", EventDate = DateTime.Now, Seats = new List<Seat>() };
            await _dataContextMock.events.AddAsync(newEvent);
            await _dataContextMock.SaveChangesAsync();

            var updatedEvent = new Event { Name = "Updated Event", EventDate = DateTime.Now, Seats = new List<Seat>() };

            // Act
            var result = await _adminService.UpdateEvent(1, updatedEvent);

            // Assert
            Assert.Equals(updatedEvent.Name, result.Name);
            Assert.Equals(updatedEvent.Seats, result.Seats);
        }

        [Test]
        public void UpdateEvent_InvalidId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var updatedEvent = new Event { Name = "Updated Event", EventDate = DateTime.Now, Seats = new List<Seat>() };

            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _adminService.UpdateEvent(99, updatedEvent));
        }

        [Test]
        public async Task DeleteEvent_ValidId_ReturnsTrue()
        {
            // Arrange
            var newEvent = new Event { Id = 1, Name = "Test Event", EventDate = DateTime.Now, Seats = new List<Seat>() };
            await _dataContextMock.events.AddAsync(newEvent);
            await _dataContextMock.SaveChangesAsync();

            // Act
            var result = await _adminService.DeleteEvent(1);

            // Assert
            Assert.Equals(result, true);
        }

        [Test]
        public void DeleteEvent_InvalidId_ThrowsKeyNotFoundException()
        {
            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _adminService.DeleteEvent(99));
        }
    }
}
