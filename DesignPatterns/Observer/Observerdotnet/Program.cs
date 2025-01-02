using Observer.Classes;
using Observer.Interfaces;
using System;
class Program
{
    public static void Main(string[] args)
    {
        var phoneDevice = new Phone();
        var computerDevice = new Computer();
        var deviceList = new List<IDevice>();
        var weatherStation = new WeatherStation(deviceList, 23, "summer", false);
        weatherStation.attach(phoneDevice);
        weatherStation.attach(computerDevice);
        weatherStation.update();
        weatherStation.detach(computerDevice);
        weatherStation.update();


    }
}
