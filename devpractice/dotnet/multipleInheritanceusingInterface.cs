using System;

public interface IVehicle
{
    void Drive();
}

public interface IElectronic
{
    void TurnOn();
    void TurnOff();
}

public class ElectricCar : IVehicle, IElectronic
{
    public void Drive()
    {
        Console.WriteLine("Driving the electric car!");
    }

    public void TurnOn()
    {
        Console.WriteLine("Electric car is powered on.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Electric car is powered off.");
    }
}

public class Program
{
    public static void Main()
    {
        ElectricCar car = new ElectricCar();
        car.Drive();    // From IVehicle
        car.TurnOn();   // From IElectronic
        car.TurnOff();  // From IElectronic
    }
}
