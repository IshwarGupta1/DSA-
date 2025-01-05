using TicketBooking.Models;

public interface ISeatService
{
    public Task<BookingResponse> BookSeat(int eventId, int userId);
    public Task<bool> IsSeatAvailableForEvent(int seatId, int eventId);
    public Task<BookingResponse> BookSeatByCategory(int eventId, int userId, SeatType category);
}
