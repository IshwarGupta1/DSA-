using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public double Balance { get; private set; }

        // Lock object to protect access to the Balance property
        private readonly object _balanceLock = new object();

        public Account(string accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        // Method to withdraw money from the account
        public bool Withdraw(double amount)
        {
            lock (_balanceLock) // Locking the account balance during withdrawal
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    return true;
                }
                return false;
            }
        }

        // Method to deposit money into the account
        public void Deposit(double amount)
        {
            lock (_balanceLock) // Locking the account balance during deposit
            {
                Balance += amount;
            }
        }
    }
}
