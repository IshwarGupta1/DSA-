namespace ParkingLot
{
    public class ParkingSystem
    {
        private Parkinglot parkingLot { get; set; }
        private PaymentContext paymentContext { get; set; }
        public ParkingSystem(Parkinglot parkingLot, PaymentContext paymentContext)
        {
            this.parkingLot = parkingLot;
            this.paymentContext = paymentContext;
        }

        public void assignParkingSpot(Vehicle vehicle)
        {
            foreach(var parkingSpots in parkingLot.parkingSpots)
            {
                if(parkingSpots!=null)
                {
                    int ind = 0;
                    foreach(var parkingSpot in parkingSpots) 
                    {
                        if(parkingSpot!=null)
                        {
                            if (parkingSpot.status == Status.Available && parkingSpot.vehicleType == vehicle.type)
                            {
                                parkingSpot.status = Status.Occupied;
                                var ticket = new Ticket();
                                ticket.id = $"{vehicle.id}_{parkingSpot.id}_{parkingSpot.vehicleType}_{ind}";
                                ticket.entryTime = DateTime.Now;
                                vehicle.ticket = ticket;
                                Console.WriteLine($"Vehicle {vehicle.id} is parked");
                                return;
                            }
                            ind++;
                        }
                    }
                }
            }
            Console.WriteLine("Vehicle Could not be parked");
            return;
        }

        public void freeParkingLot(Vehicle vehicle, string modeofPayment)
        {
            var ticket = vehicle.ticket;
            var ticketParts = ticket.id.Split('_');
            var parkingSpotid = ticketParts[1];
            var floorNum = Convert.ToInt32(ticketParts[3]);
            var parkingSpots = parkingLot.parkingSpots[floorNum];
            foreach(var parkingSpot in parkingSpots)
            {
                if (parkingSpot.id.Equals(parkingSpotid))
                {
                    parkingSpot.status = Status.Available;
                    break;
                }
            }
            var entryTime = ticket.entryTime;
            var exitTime = DateTime.Now;
            var duration = (exitTime - entryTime).TotalSeconds;
            double amount = getAmount(duration, ticketParts[2]);
            if(modeofPayment == "CC")
            {
                paymentContext.payment(new CCPaymentStrategy(), amount);
            }
            else
                paymentContext.payment(new UPIPaymentStrategy(), amount);
        }
        private double getAmount(double duration, string vehicleType)
        {
            switch(vehicleType)
            {
                case "Bike":
                    return duration * 10;
                case "Car":
                    return duration * 15;
                case "Truck":
                    return duration * 20;
                default: return -1;
            }
        }
    }
}
