using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Interfaces
{
    //subject interface
    public interface IDevice
    {
        public void update(int temp, string weather, bool rain);
    }
}
