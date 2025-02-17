using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Manager : Employee
    {
        public string _team;

        public Manager(string team, string name, int empId) : base(name, empId)
        {
            _team = team;
        }

        public override void workToDo()
        {
            Console.WriteLine($"Manager manages team {_team}");
        }
    }
}
