namespace TicketBooking.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public string seatNum { get; set; } = string.Empty;
        public bool isAvailable { get; set; }
        public SeatType seatType { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
