namespace parkinglot
{
    public class Truck : Vehicle
    {
        public Truck(string vehicleNum, VehicleType vehicleType) : base(vehicleNum, vehicleType)
        {
            this.vehicleType = VehicleType.Large;
        }
    }
}
