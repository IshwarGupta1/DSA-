namespace ScrumPoker.Models
{
    public class User
    {
        public int UserId { get; set; } // primary key
        public string UserName { get; set; } // name
        public string Role { get; set; } // Dev or QA
    }
}
