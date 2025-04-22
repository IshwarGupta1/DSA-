using System;
using System.Collections.Generic;

namespace ATM
{
    internal class ATM
    {
        private CashDispenser cashDispenser;
        private List<Account> accounts;

        public ATM(List<Account> accounts)
        {
            this.accounts = accounts;
            cashDispenser = new CashDispenser(null, accounts);
        }

        public void Deposit(Card card, double amount, string pin)
        {
            cashDispenser.deposit(card, amount, pin);
        }

        public void Withdraw(Card card, double amount, string pin)
        {
            cashDispenser.Withdraw(card, amount, pin);
        }

        public void ShowBalance(Card card, string pin)
        {
            foreach (var account in accounts)
            {
                if (account.getCardDetails().getCardID() == card.getCardID() && card.getCardPin() == pin)
                {
                    Console.WriteLine($"Balance: {account.getBalance()}");
                    return;
                }
            }
            throw new ArgumentException("Invalid card or PIN");
        }
    }
}
