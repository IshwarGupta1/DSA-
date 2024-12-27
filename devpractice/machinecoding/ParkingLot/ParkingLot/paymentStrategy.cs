using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public interface paymentStrategy
    {
        public void pay(double amount);
    }
}
