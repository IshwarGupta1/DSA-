using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    static class lock1
    {
        static int balance = 500;
        static object locker = new object();
        public static void withdraw()
        {
            lock(locker)
            {
                balance = balance + 100;
                Console.WriteLine($"new balance added {balance}");
            }
        }
    }
}
