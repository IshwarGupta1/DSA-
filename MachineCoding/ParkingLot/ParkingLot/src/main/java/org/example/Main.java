package org.example;

import java.util.HashMap;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        ParkingLot parkingLot = new ParkingLot(3, 10);
        parkingLot.setSpotList();
        HashMap<VehicleType, Integer> parkingCharge = new HashMap<>();
        parkingCharge.put(VehicleType.Car, 25);
        parkingCharge.put(VehicleType.Bike, 15);
        ParkingManager parkingManager = new ParkingManager(parkingLot, parkingCharge);
        Vehicle vehicle1 = new Vehicle(VehicleType.Bike, "Blue", "WB12345678");
        Vehicle vehicle2 = new Vehicle(VehicleType.Car, "Red", "JH12345678");
        parkingManager.parkVehicle(vehicle1);
        parkingManager.parkVehicle(vehicle2);
        Thread.sleep(1000);
        parkingManager.unParkVehicle(vehicle2.ticket, "Cash");
    }
}