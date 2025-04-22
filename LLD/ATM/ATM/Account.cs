using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Account
    {
        private string AccountId { get; set; }
        private double Balance { get; set; }
        private Card card { get; set; }
        public Account(string accountId, double balance, Card card)
        {
            AccountId = accountId;
            Balance = balance;
            this.card = card;
        }

        public string getAccountId()
        {
            return AccountId;
        }

        public Card getCardDetails ()
        {
            return card;
        }
        public double getBalance()
        {
            return Balance;
        }
        public void setBalance(double amount, bool deposit)
        {
            if(deposit)
                Balance = Balance + amount;
            else
            {
                if (Balance < amount)
                    throw new ArgumentException("balance is low");
                Balance = Balance - amount;
            }
        }
    }
}
