using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//concrete product
namespace AbstractFactory
{
    public class MacCheckBox : ICheckBox
    {
        public void checkBox()
        {
            Console.WriteLine("Select Mac Button");
        }
    }
}
