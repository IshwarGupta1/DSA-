using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskmanagement.Models
{
    public class workTask
    {
        public int id { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public DateTime dueDate { get; set; }
        public Priority priority { get; set; }
        public Status status { get; set; }
    }
}
