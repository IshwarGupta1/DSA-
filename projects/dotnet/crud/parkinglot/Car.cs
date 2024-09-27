namespace parkinglot
{
    public class Car : Vehicle
    {
        public Car(string vehicleNum, VehicleType vehicleType) : base(vehicleNum, vehicleType)
        {
            this.vehicleType = VehicleType.Medium;
        }
    }
}
