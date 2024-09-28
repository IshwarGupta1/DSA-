using parkinglot;

var car = new Car("Toyota");
var parkingLot = new ParkingLot(car);

string parkingSpot = parkingLot.AssignParkingSpot(1);
Console.WriteLine(parkingSpot);

string ticket = parkingLot.AssignTicket();
Console.WriteLine(ticket);

// After some time, charge for the parking:
double payment = parkingLot.chargePayment();
Console.WriteLine($"Total Charge: {payment}");
