using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// concrete button
namespace AbstractFactory
{
    public class MacButton : IButton
    {
        public void button()
        {
            Console.WriteLine("Click Mac Button");
        }
    }
}
