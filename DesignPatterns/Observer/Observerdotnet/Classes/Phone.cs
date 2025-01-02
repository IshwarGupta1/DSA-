using Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Classes
{
    //concrete observer
    public class Phone : IDevice
    {
        public void update(int temp, string weather, bool rain)
        {
            Console.WriteLine("Phone Update-----");
            Console.WriteLine($"Today's temperature is {temp}");
            Console.WriteLine($"Weather is {weather}");
            var rainPossibility = rain ? "Today it can rain" : "Today it won't rain";
            Console.WriteLine(rainPossibility);
        }
    }
}
