namespace parkinglot
{
    public class ParkingLot
    {
        public Vehicle vehicle;
        public ParkingSpot parkingSpot;
        public Ticket ticket;
        public double charge = 20;
        List<int>parkingSpotId = new List<int>();
        public ParkingLot(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        public string AssignParkingSpot(int floor)
        {
            var random = new Random();
            var id = random.Next(1, 100);
            if (parkingSpotId.Count >=100)
                return "No parking spots available";
            do
            {
                id = random.Next(1, 101);
            } while (parkingSpotId.Contains(id));
            parkingSpotId.Add(id);
            return parkingSpot.ParkingSpotLocation(floor, vehicle.vehicleType, id);
        }

        public string AssignTicket(int floor)
        {
            return ticket.ticketId(parkingSpot.id, vehicle.vehicleName);
        }

        public double chargePayment()
        {
            ticket.exitTime = DateTime.UtcNow;
            return ticket.duration(ticket.entryTime, ticket.exitTime, charge);
        }
    }
}
