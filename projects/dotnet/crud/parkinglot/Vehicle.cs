namespace parkinglot
{
    public abstract class Vehicle
    {
        public string vehicleName { get; set; }
        public VehicleType vehicleType { get; set; }
        public Vehicle(string vehicleName, VehicleType vehicleType)
        {
            this.vehicleName = vehicleName;
            this.vehicleType = vehicleType;
        }
    }
}
