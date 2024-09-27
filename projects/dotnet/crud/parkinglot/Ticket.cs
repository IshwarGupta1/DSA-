namespace parkinglot
{
    public class Ticket
    {
        public int id { get; set; }
        public string VehicleName { get; set; }
        public DateTime entryTime { get; set; }
        public DateTime exitTime { get; set; }
        public Ticket(int id, string vehicleName, DateTime entryTime, DateTime exitTime)
        {
            this.id = id;
            VehicleName = vehicleName;
            this.entryTime = entryTime;
            this.exitTime = exitTime;
        }

        public string ticketId(int id, string vehicleName)
        {
            return id.ToString()+ ":" + vehicleName;
        }

        public double duration(DateTime entryTime, DateTime exitTime, double rate)
        {
            var hrs =  (exitTime-entryTime).TotalHours;
            var mins = (exitTime-entryTime).TotalMinutes;
            var secs = (exitTime-entryTime).TotalSeconds;
            return rate * hrs + rate * mins / 60 + rate * secs/3600;
        }
    }
}
