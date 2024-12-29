namespace StackOverflow
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IList<Question> Questions { get; set; } = new List<Question>();
        public User(string userId, string userName) {
            UserId = userId;
            UserName = userName;
        }
    }
}
