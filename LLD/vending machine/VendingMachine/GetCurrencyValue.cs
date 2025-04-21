using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    static class GetCurrencyValue
    {
        public static int GetValue(this Coin coin)
        {
            return (int)coin;
        }

        public static int GetValue(this Note note)
        {
            return (int)note;
        }
    }
}
