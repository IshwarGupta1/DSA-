package Entities;
import java.time.Duration;
import java.time.Instant;
import java.util.*;

public class Manager {
    private ParkingLot parkingLot;
    private HashMap<Vehicle, Ticket> parkedVehicles;
    public Manager(ParkingLot parkingLot)
    {
        this.parkingLot = parkingLot;
        this.parkedVehicles = new HashMap<>();
    }
    public void assignSpot(Vehicle vehicle)
    {
        List<ParkingSpot> spots = parkingLot.availableParkingSpots(vehicle);
        if(spots.isEmpty())
            System.out.println("No parking spot available");
        ParkingSpot spot = spots.get(0);
        spot.status = Status.Occupied;
        spot.vehicleSize = vehicle.size;
        spot.vehicleType = vehicle.type;
        Ticket ticket = new Ticket();
        ticket.VehicleNum = vehicle.vehicleNumber;
        ticket.EntryTime = (Instant.now());
        ticket.spot = spot;
        ticket.TicketId = vehicle.vehicleNumber + vehicle.OwnerName + vehicle.size + vehicle.type;
        parkedVehicles.put(vehicle,ticket);
    }

    public double collectFees(Vehicle vehicle)
    {
        Ticket ticket = parkedVehicles.get(vehicle);
        if (ticket == null) {
            System.out.println("No ticket found for vehicle " + vehicle.vehicleNumber);
            return 0.0;
        }
        Instant entryTime = ticket.EntryTime;
        Instant exitTime = Instant.now();
        var spot = ticket.spot;
        if (spot.vehicleType == null || spot.vehicleSize == null) {
            System.out.println("Error: Parking spot vehicle attributes are missing.");
            return 0.0;
        }

        double fees = parkingLot.parkingSpotFees(spot);
        double duration = Duration.between(entryTime, exitTime).toMillis();
        spot.status = Status.Free;
        spot.vehicleSize = null;
        spot.vehicleType = null;
        parkedVehicles.remove(vehicle, ticket);
        return fees * duration;
    }
}
