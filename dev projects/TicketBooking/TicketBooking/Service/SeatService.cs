using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Models;

namespace TicketBooking.Service
{
    public class SeatService : ISeatService
    {
        private readonly DataContext _dataContext;
        private readonly BookingHub _hubContext;
        public SeatService(DataContext dataContext, BookingHub hubContext)
        {
            _dataContext = dataContext;
            _hubContext = hubContext;
        }

        public async Task<BookingResponse> BookSeat(int eventId, int userId)
        {
            var reqEvent = await _dataContext.events.FirstOrDefaultAsync(e => e.Id == eventId);
            if (reqEvent == null)
                throw new ArgumentNullException("event does not exist");

            var availableSeats = reqEvent.Seats.Where(s => s.isAvailable == true).OrderBy(s => s.seatNum).ToList();
            if (availableSeats.Count == 0)
            {
                throw new Exception("no seats available");
            }

            var bookingSeat = availableSeats.First();
            bookingSeat.isAvailable = false;

            try
            {
                var booking = new Booking
                {
                    BookingTime = DateTime.Now,
                    EventId = eventId,
                    SeatId = bookingSeat.Id,
                    UserId = userId
                };

                var user = await _dataContext.user.FirstOrDefaultAsync(u => u.userId == userId);
                user.bookings.Add(booking);
                await _dataContext.AddAsync(booking);
                await _dataContext.SaveChangesAsync();

                var response = new BookingResponse
                {
                    bookingId = booking.Id,
                    bookingTime = booking.BookingTime,
                    seatId = bookingSeat.Id,
                };

                // SignalR: Notify clients that a seat was booked
                await _hubContext.Clients.All.SendAsync("SeatBooked", bookingSeat.Id);

                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Concurrency conflict occurred while booking the seat.");
            }
        }

            public async Task<BookingResponse> BookSeatByCategory(int eventId, int userId, SeatType category)
        {
            var reqEvent = _dataContext.events.FirstOrDefault(e => e.Id == eventId);
            if (reqEvent == null)
                throw new ArgumentNullException("event does not exist");
            var availableSeats = reqEvent.Seats.Where(s => s.isAvailable == true && s.seatType == category).OrderBy(s => s.seatNum).ToList();
            if (availableSeats.Count == 0)
            {
                throw new Exception("no seats available");
            }
            var bookingSeat = availableSeats.First();
            bookingSeat.isAvailable = false;
            var booking = new Booking
            {
                BookingTime = DateTime.Now,
                EventId = eventId,
                SeatId = bookingSeat.Id,
                UserId = userId
            };
            var user = _dataContext.user.FirstOrDefault(u => u.userId == userId);
            user.bookings.Add(booking);
            await _dataContext.AddAsync(booking);
            await _dataContext.SaveChangesAsync();
            var response = new BookingResponse
            {
                bookingId = booking.Id,
                bookingTime = booking.BookingTime,
                seatId = bookingSeat.Id,
            };
            return response;
        }

        public async Task<bool> IsSeatAvailableForEvent(int seatId, int eventId)
        {
            var reqEvent = _dataContext.events.FirstOrDefault(e => e.Id == eventId);
            if(reqEvent == null)
                throw new ArgumentNullException("event does not exist");
            var seat = _dataContext.seat.FirstOrDefault(seat => seat.Id == seatId);
            if(!reqEvent.Seats.Contains(seat))
            {
                throw new ArgumentOutOfRangeException("seat is not of this event");
            }
            return seat.isAvailable;
        }
    }
}
