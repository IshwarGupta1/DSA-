using TicketBooking.Models;

namespace TicketBooking.Service
{
    public interface IUserService
    {
        public Task<IList<Event>> GetAvailableEvents();
        public Task<bool> IsSeatAvailableForEvent(int seatId, int eventId);
        public Task<IList<Booking>> listAllBookings(int userId);
        public Task<BookingResponse> bookSeat(int userId, int eventId);
        public Task<BookingResponse> bookSeatByCategory(int userId, int eventId, SeatType type);
        public Task CancelBooking(int userId, int bookingId);
    }
}
