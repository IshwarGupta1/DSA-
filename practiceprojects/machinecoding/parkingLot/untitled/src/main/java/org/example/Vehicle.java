package org.example;

public class Vehicle {
    VehicleType vehicleType;
    String vehicleNumber;
    String color;
    String ticket;

    public Vehicle(VehicleType vehicleType, String vehicleNumber, String color) {
        this.vehicleType = vehicleType;
        this.vehicleNumber = vehicleNumber;
        this.color = color;
    }
}
