using Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Classes
{
    //Concrete subject
    public class WeatherStation : IWeatherStation
    {
        public List<IDevice> _devices;
        int _temp;
        string _weather;
        bool _rain;
        public WeatherStation(List<IDevice> devices, int temp, string weather, bool rain)
        {
            _devices = devices;
            _temp = temp;
            _weather = weather;
            _rain = rain;
        }

        public void attach(IDevice device)
        {
            _devices.Add(device);
        }

        public void detach(IDevice device)
        {
            _devices?.Remove(device);
        }

        public void update()
        {
            foreach(var device in _devices)
            {
                device.update(_temp, _weather, _rain);
            }
        }
    }
}
