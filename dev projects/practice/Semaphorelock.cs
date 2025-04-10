using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    static class Semaphorelock
    {
        static int ticket = 1;
        static Semaphore washroom = new Semaphore(2, 4);
        public static void goWashroom()
        {
            washroom.WaitOne();
            Console.WriteLine("Washroom ticket booked");
            washroom.Release();
            Console.WriteLine("Waiting");
        }
    }
}

