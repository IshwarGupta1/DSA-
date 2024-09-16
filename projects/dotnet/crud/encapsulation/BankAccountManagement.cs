using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encapsulation
{
    public class BankAccountManagement
    {
        private Decimal _balance; 
        private Decimal _minimumBalance;
        public BankAccountManagement(Decimal balance, decimal minimumBalance)
        {
            _balance = balance;
            _minimumBalance = minimumBalance;
        }
        public void withdraw(Decimal amount)
        {
            if (amount > _balance)
                throw new Exception("not enough balance");
            var remainingBalance = _balance - amount;
            if (remainingBalance < _minimumBalance)
            {
                throw new Exception("remaining Balance is going less than minimumBalance");
            }
            Console.WriteLine($"Amount withdrawn {amount}. Remaining Balance is {remainingBalance}");
        }
    }
}
