using Microsoft.EntityFrameworkCore;
using TicketBooking.Models;

namespace TicketBooking.Service
{
    public class AdminService : IAdminService
    {
        private readonly DataContext _dataContext;

        public AdminService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Create Event
        public async Task<Event> CreateEvent(Event newEvent)
        {
            if (newEvent == null)
                throw new ArgumentNullException(nameof(newEvent));

            await _dataContext.events.AddAsync(newEvent);
            await _dataContext.SaveChangesAsync();
            return newEvent;
        }

        // Read Event by ID
        public async Task<Event> GetEventById(int eventId)
        {
            var eventEntity = await _dataContext.events.FindAsync(eventId);
            if (eventEntity == null)
                throw new KeyNotFoundException($"Event with ID {eventId} not found.");
            return eventEntity;
        }

        // Read All Events
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _dataContext.events.ToListAsync();
        }

        // Update Event
        public async Task<Event> UpdateEvent(int eventId, Event updatedEvent)
        {
            var eventEntity = await _dataContext.events.FindAsync(eventId);
            if (eventEntity == null)
                throw new KeyNotFoundException($"Event with ID {eventId} not found.");

            eventEntity.Name = updatedEvent.Name;
            eventEntity.EventDate = updatedEvent.EventDate;
            eventEntity.Seats = updatedEvent.Seats; // Ensure seats are updated logically
                                                    // Update other fields as needed...

            await _dataContext.SaveChangesAsync();
            return eventEntity;
        }

        // Delete Event
        public async Task<bool> DeleteEvent(int eventId)
        {
            var eventEntity = await _dataContext.events.FindAsync(eventId);
            if (eventEntity == null)
                throw new KeyNotFoundException($"Event with ID {eventId} not found.");

            _dataContext.events.Remove(eventEntity);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }

}
