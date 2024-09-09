namespace ScrumPoker.Models
{
    public class Vote
    {
        public int VoteId { get; set; } // Primary key
        public int UserId { get; set; } // ID of the user who voted
        public int SessionId { get; set; } // ID of the session in which the vote was cast
        public int CardId { get; set; } // ID of the card voted for
        public User User { get; set; } // Navigation property for User
        public Session Session { get; set; } // Navigation property for Session
        public Card Card { get; set; } // Navigation property for Card
    }

}
