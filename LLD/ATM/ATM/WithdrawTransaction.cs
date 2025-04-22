using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class WithdrawTransaction : ITransaction
    {
        public void transact(Account account, double amount)
        {
            account.setBalance(amount, false);
            return;
        }
    }
}
