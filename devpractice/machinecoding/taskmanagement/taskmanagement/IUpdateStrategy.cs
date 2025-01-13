using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskmanagement.Models;

namespace taskmanagement
{
    public interface IUpdateStrategy
    {
        void Update(workTask task);
    }
}
