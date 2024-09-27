namespace parkinglot
{
    public class Bike : Vehicle
    {
        public Bike(string vehicleNum, VehicleType vehicleType) : base(vehicleNum, vehicleType)
        {
            this.vehicleType = VehicleType.Small;
        }
    }
}

