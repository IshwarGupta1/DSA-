namespace ScrumPoker.Models
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public string passwordHash { get; set; } = string.Empty;
        public Role userRole { get; set; }
    }
}
