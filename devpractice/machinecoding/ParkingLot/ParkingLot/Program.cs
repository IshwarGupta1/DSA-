using ParkingLot;

var parkingLot = new Parkinglot(1, 4);

for(int i=0;i<4;i++)
{
    List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
    var parkingSpotBike = new ParkingSpot($"b{i}", i + 1, VehicleType.Bike, Status.Available);
    var parkingSpotCar = new ParkingSpot($"c{i}", i + 1, VehicleType.Car, Status.Available);
    var parkingSpotTruck = new ParkingSpot($"t{i}", i + 1, VehicleType.Truck, Status.Available);
    parkingSpots.Add(parkingSpotBike);
    parkingSpots.Add (parkingSpotCar);
    parkingSpots.Add(parkingSpotTruck);
    parkingLot.parkingSpots.Add(parkingSpots);
}
var paymentContext = new PaymentContext();
var parkingSystem = new ParkingSystem(parkingLot, paymentContext);
var veh1 = new Vehicle(1, VehicleType.Bike);
parkingSystem.assignParkingSpot(veh1);
Thread.Sleep(5000);
parkingSystem.freeParkingLot(veh1, "CC");
var veh2 = new Vehicle(2, VehicleType.Car);
parkingSystem.assignParkingSpot(veh2);
Thread.Sleep(5000);
parkingSystem.freeParkingLot(veh2, "UPI");


