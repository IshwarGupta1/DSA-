package Entities;

public class ParkingSpot {
    String ParkingId;
    Status status;
    VehicleSize vehicleSize;
    VehicleType vehicleType;

    public ParkingSpot(String parkingId, Status status, VehicleSize vehicleSize, VehicleType vehicleType) {
        ParkingId = parkingId;
        this.status = status;
        this.vehicleSize = vehicleSize;
        this.vehicleType = vehicleType;
    }
}
