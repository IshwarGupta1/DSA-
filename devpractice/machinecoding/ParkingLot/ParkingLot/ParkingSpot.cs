namespace ParkingLot
{
    public class ParkingSpot
    {
        public string id { get; set; }
        public int floorNum { get; set; }
        public VehicleType vehicleType { get; set; }
        public Status status { get; set; }
        public ParkingSpot(string id, int floorNum, VehicleType vehicleType, Status status)
        {
            this.id = id;
            this.floorNum = floorNum;
            this.vehicleType = vehicleType;
            this.status = status;
        }
    }
}
