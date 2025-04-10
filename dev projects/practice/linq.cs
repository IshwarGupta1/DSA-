using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    public class linq
    {
        public void practice()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var res1 = numbers.Where(n => n % 2 == 0).Select(n => n * 10).ToList();

            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ram", Salary=4000},
                new Employee{Id=2, Name="Shyam", Salary=8000},
                new Employee{Id=3, Name="Mohan", Salary=6000},
                new Employee{Id=4, Name="Sita", Salary=10000}
            };
            var res2 = employees.Select(e => e.Salary > 5000).ToList();

            List<string> fruits = new List<string>
            {
                "apple", "banana", "apple", "mango", "banana", "apple", "grapes"
            };

            
        }
    }
}