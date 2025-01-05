namespace TicketBooking.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}
