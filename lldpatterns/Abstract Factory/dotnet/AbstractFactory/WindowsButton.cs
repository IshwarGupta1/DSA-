using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// concrete product
namespace AbstractFactory
{
    public class WindowsButton : IButton
    {
        public void button()
        {
            Console.WriteLine("Click WindowsButton");
        }
    }
}
