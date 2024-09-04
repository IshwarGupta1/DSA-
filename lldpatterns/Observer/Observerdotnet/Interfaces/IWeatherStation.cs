using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Interfaces
{
    // subject interface
    public interface IWeatherStation
    {
        public void attach(IDevice device);
        public void detach(IDevice device);
        public void update();
    }
}
