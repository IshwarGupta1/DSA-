namespace ParkingLot
{
    public class Ticket
    {
        public string id {  get; set; }
        public DateTime entryTime { get; set; } = DateTime.MaxValue;
        public DateTime exitTime { get; set; } = DateTime.MinValue;
    }
}
