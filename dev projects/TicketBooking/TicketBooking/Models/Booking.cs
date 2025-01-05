namespace TicketBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SeatId { get; set; }
        public int EventId { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
