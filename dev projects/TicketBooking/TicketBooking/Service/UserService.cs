using Microsoft.EntityFrameworkCore;
using TicketBooking.Models;

namespace TicketBooking.Service
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly ISeatService _seatService;
        public UserService(DataContext dataContext, ISeatService seatService)
        {
            _dataContext = dataContext;
            _seatService = seatService;
        }

        public async Task<IList<Event>> GetAvailableEvents()
        {
            // Fetch events with at least one available seat
            var events = await _dataContext.events
                .Where(e => e.Seats.Any(s => s.isAvailable))
                .ToListAsync();

            return events;
        }

        public Task<bool> IsSeatAvailableForEvent(int seatId, int eventId)
        {
            return _seatService.IsSeatAvailableForEvent(seatId, eventId);
        }

        public Task<BookingResponse> bookSeat(int userId, int eventId)
        {
            return _seatService.BookSeat(userId, eventId);
        }

        public Task<BookingResponse> bookSeatByCategory(int userId, int eventId, SeatType type)
        {
            return _seatService.BookSeatByCategory(userId, eventId, type);
        }

        public async Task CancelBooking(int userId, int bookingId)
        {
            var user = _dataContext.user.FirstOrDefault(u => u.userId == userId);
            if (user == null)
            {
                throw new ArgumentNullException("user does not exist");
            }
            var booking = user.bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null)
            {
                throw new ArgumentException("Booking does not exist.");
            }
            user.bookings.Remove(booking);
            var reqEvent = _dataContext.events.FirstOrDefault(s => s.Id ==booking.EventId);
            if (reqEvent == null)
            {
                throw new ArgumentException("Event does not exist.");
            }
            var seat = reqEvent.Seats.FirstOrDefault(s => s.Id == booking.SeatId);
            if (seat == null)
            {
                throw new ArgumentException("seat does not exist.");
            }
            seat.isAvailable = true;
            _dataContext.booking.Remove(booking);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IList<Booking>> listAllBookings(int userId)
        {
            var user = _dataContext.user.FirstOrDefault(u => u.userId == userId);
            if(user == null)
            {
                throw new ArgumentNullException("user does not exist");
            }
            var bookings = user.bookings;
            return bookings;
        }
    }
}
