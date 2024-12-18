using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_Delegates
{
    public class Subscriber
    {
        public void Triggered(string message)
        {
            Console.WriteLine(message);
        }
    }
}
