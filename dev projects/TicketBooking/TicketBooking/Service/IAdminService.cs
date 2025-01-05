using TicketBooking.Models;

namespace TicketBooking.Service
{
    public interface IAdminService
    {
        Task<Event> CreateEvent(Event newEvent);
        Task<Event> GetEventById(int eventId);
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> UpdateEvent(int eventId, Event updatedEvent);
        Task<bool> DeleteEvent(int eventId);
    }

}
