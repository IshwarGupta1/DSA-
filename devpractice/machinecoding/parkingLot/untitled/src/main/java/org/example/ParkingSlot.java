package org.example;

public class ParkingSlot {
    VehicleType slotType;
    String slotNumber;
    int floor;
    Status status;

    public ParkingSlot(VehicleType slotType, String slotNumber, int floor, Status status) {
        this.slotType = slotType;
        this.slotNumber = slotNumber;
        this.floor = floor;
        this.status = status;
    }
}
