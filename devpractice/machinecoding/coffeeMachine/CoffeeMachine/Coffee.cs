using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class Coffee : ICoffee
    {
        public virtual string getDescription()
        {
            return "Plain Coffee";
        }

        public virtual double getPrice()
        {
            return 10.0;
        }
    }
}
