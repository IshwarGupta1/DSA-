using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class PaymentContext
    {
        public void payment(paymentStrategy strategy, double amount)
        {
            strategy.pay(amount);
        }
    }
}
