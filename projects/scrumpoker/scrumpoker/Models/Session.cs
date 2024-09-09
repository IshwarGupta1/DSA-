namespace ScrumPoker.Models
{
    public class Session
    {
        public int SessionId { get; set; } // Primary key
        public string Name { get; set; } // Name of the session
        public DateTime StartTime { get; set; } // When the session started
        public DateTime? EndTime { get; set; } // When the session ended (optional)
        public ICollection<Vote> Votes { get; set; } // Votes cast during the session
        public ICollection<User> Users { get; set; } // Users participating in the session
    }
}
