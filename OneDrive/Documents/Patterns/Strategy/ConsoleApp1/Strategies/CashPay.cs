using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Strategies
{
    public class CashPay : IPay
    {
        public void Pay(int amount)
        {
            Console.WriteLine($"Cash Paid--{amount}");
        }
    }
}
