using Microsoft.EntityFrameworkCore;
using TicketBooking.Models;

namespace TicketBooking
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> user { get; set; }
        public DbSet<Seat> seat { get; set; }
        public DbSet<Booking> booking { get; set; }
        public DbSet<Event> events { get; set; }
    }
}
