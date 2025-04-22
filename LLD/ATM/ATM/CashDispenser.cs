using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class CashDispenser
    {
        private ITransaction transaction;
        private readonly List<Account> accounts;
        public CashDispenser(ITransaction transaction, List<Account> accounts)
        {
            this.transaction = transaction;
            this.accounts = accounts;
        }

        public void deposit(Card card, double amount, string PIN)
        {
            lock (accounts)
            {
                foreach (var account in accounts)
                {
                    if (account.getCardDetails().getCardID() == card.getCardID() && card.getCardPin() == PIN)
                    {
                        transaction = new DepositTransaction();
                        transaction.transact(account, amount);
                        return;
                    }
                }
            }
            throw new ArgumentException("Wrong excecption");
        }

        public void Withdraw(Card card, double amount, string PIN)
        {
            lock (accounts)
            {
                foreach (var account in accounts)
                {
                    if (account.getCardDetails().getCardID() == card.getCardID() && card.getCardPin() == PIN)
                    {
                        transaction = new WithdrawTransaction();
                        transaction.transact(account, amount);
                        return;
                    }
                }
            }
            throw new ArgumentException("Invalid card or PIN");
        }
    }
}
