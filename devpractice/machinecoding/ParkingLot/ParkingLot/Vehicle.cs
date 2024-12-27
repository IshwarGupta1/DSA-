namespace ParkingLot
{
    public class Vehicle
    {
        public int id { get; set; }
        public VehicleType type { get; set; }
        public Ticket ticket { get; set; } = new Ticket();
        public Vehicle(int id, VehicleType type)
        {
            this.id = id;
            this.type = type;
        }
    }

}
