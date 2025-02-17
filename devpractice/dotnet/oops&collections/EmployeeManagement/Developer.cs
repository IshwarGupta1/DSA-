using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Developer : Employee
    {
        public string _devLang;
        public Developer(string devLang, string name, int empId) : base(name, empId)
        {
            _devLang = devLang;
        }

        public override void workToDo()
        {
            Console.WriteLine($"Developer writes code in {_devLang}");
        }
    }
}
