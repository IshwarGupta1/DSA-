using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskmanagement.Models
{
    public class User
    {
        public int userId { get; set; }
        public string name { get; set; }
        public List<workTask> tasks { get; set; }
    }
}
