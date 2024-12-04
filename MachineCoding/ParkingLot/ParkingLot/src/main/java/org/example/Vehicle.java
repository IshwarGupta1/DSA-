package org.example;

import java.time.LocalDateTime;

public class Vehicle {
    VehicleType vehicleType;
    String Color;
    String vehicleNumber;
    Ticket ticket = new Ticket("", LocalDateTime.MIN, LocalDateTime.MAX);

    public Vehicle(VehicleType vehicleType, String color, String vehicleNumber) {
        this.vehicleType = vehicleType;
        Color = color;
        this.vehicleNumber = vehicleNumber;
    }

    public VehicleType getVehicleType() {
        return vehicleType;
    }

    public Ticket getTicket() {
        return ticket;
    }

    public void setTicket(Ticket ticket) {
        this.ticket = ticket;
    }

    public String getVehicleNumber() {
        return vehicleNumber;
    }
}
