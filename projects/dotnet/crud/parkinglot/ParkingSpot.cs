namespace parkinglot
{
    public class ParkingSpot
    {
        public int floor { get; set; }
        public VehicleType type { get; set; }
        public int id { get; set; }
        public ParkingSpot(int floor, VehicleType type, int id)
        {
            this.floor = floor;
            this.type = type;
            this.id = id;
        }
        public string ParkingSpotLocation(int floor, VehicleType type, int id)
        {
            return floor.ToString()+type.ToString()+id.ToString();
        }
    }
}
