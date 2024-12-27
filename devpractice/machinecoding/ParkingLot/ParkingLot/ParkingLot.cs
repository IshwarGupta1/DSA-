namespace ParkingLot
{
    public class Parkinglot
    {
        public int id {  get; set; }
        public int numberofFloors { get; set; }
        public IList<IList<ParkingSpot>> parkingSpots { get; set; } = new List<IList<ParkingSpot>>();
        public Parkinglot(int id, int numberofFloors)
        {
            this.id = id;
            this.numberofFloors = numberofFloors;
        }
    }
}
