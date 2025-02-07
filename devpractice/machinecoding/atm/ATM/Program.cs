using ATM.Models;
using System;
using System.Threading;

public class ATM
{
    public static void Main(string[] args)
    {
        // Create an account with an initial balance of 1000
        Account account = new Account("123-456-789", 1000);

        // Simulate two users attempting to withdraw from the same account concurrently
        Thread user1 = new Thread(() => WithdrawMoney(account, 600));  // User 1 withdraws 600
        Thread user2 = new Thread(() => WithdrawMoney(account, 500));  // User 2 withdraws 500

        user1.Start();
        user2.Start();

        // Wait for both threads to finish
        user1.Join();
        user2.Join();
    }

    // Method to simulate withdrawing money from an account
    public static void WithdrawMoney(Account account, double amount)
    {
        if (account.Withdraw(amount))
        {
            Console.WriteLine($"Withdrawal of {amount} successful. New balance: {account.Balance}");
        }
        else
        {
            Console.WriteLine($"Insufficient funds for withdrawal of {amount}. Current balance: {account.Balance}");
        }
    }
}
