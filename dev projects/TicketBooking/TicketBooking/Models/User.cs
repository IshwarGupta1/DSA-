namespace TicketBooking.Models
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string passwordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public IList<Booking> bookings = new List<Booking>();
    }
}
