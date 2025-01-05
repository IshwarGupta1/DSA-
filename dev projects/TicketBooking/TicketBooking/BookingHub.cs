using Microsoft.AspNetCore.SignalR;

public class BookingHub : Hub
{
    public async Task SendBookingUpdate(int seatId)
    {
        await Clients.All.SendAsync("SeatBooked", seatId);
    }
}
