namespace ATM.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string CardNumber { get; set; }
        public string Pin { get; set; }
        public Account Account { get; set; }

        public User(string userId, string cardNumber, string pin, Account account)
        {
            UserId = userId;
            CardNumber = cardNumber;
            Pin = pin;
            Account = account;
        }
    }

}
