package Entities;

public class Vehicle {
    String vehicleNumber;
    String OwnerName;
    VehicleType type;
    VehicleSize size;

    public Vehicle(String vehicleNumber, String ownerName, VehicleType type, VehicleSize size) {
        this.vehicleNumber = vehicleNumber;
        OwnerName = ownerName;
        this.type = type;
        this.size = size;
    }
}
