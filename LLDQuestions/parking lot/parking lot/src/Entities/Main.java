package Entities;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        // Sample parking spots (for the sake of example, you can expand it)
        List<ParkingSpot> spots = new ArrayList<>();
        spots.add(new ParkingSpot("P001", Status.Free, VehicleSize.Small, VehicleType.TwoWheeler));
        spots.add(new ParkingSpot("P002", Status.Free,  VehicleSize.Medium, VehicleType.FourWheeler));
        spots.add(new ParkingSpot("P003", Status.Free,  VehicleSize.Large, VehicleType.FourWheeler));
        spots.add(new ParkingSpot("P004", Status.Free,  VehicleSize.Medium, VehicleType.Handicapped));

        // Create a parking lot with the spots
        ParkingLot parkingLot = new ParkingLot(spots);

        // Create a manager to handle parking lot operations
        Manager manager = new Manager(parkingLot);

        // Create some vehicles
        Vehicle vehicle1 = new Vehicle("ABC123", "John Doe", VehicleType.TwoWheeler, VehicleSize.Small);
        Vehicle vehicle2 = new Vehicle("XYZ456", "Jane Smith", VehicleType.FourWheeler, VehicleSize.Medium);
        Vehicle vehicle3 = new Vehicle("LMN789", "Alice Johnson", VehicleType.FourWheeler, VehicleSize.Large);

        // Assign parking spots to vehicles
        manager.assignSpot(vehicle1);  // Vehicle 1
        manager.assignSpot(vehicle2);  // Vehicle 2
        manager.assignSpot(vehicle3);  // Vehicle 3

        // Simulate vehicle 1 exiting the parking lot
        try {
            // Sleep to simulate vehicle staying for some time (e.g., 2 hours)
            Thread.sleep(2000);  // Sleep for 2 seconds as a stand-in for 2 hours
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        // Collect fees for vehicle1 after it exits
        double fee1 = manager.collectFees(vehicle1);
        System.out.println("Fee collected for vehicle " + vehicle1.vehicleNumber + ": " + fee1);

        // Simulate vehicle 2 exiting the parking lot
        try {
            Thread.sleep(1000);  // Sleep for 1 second as a stand-in for 1 hour
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        // Collect fees for vehicle2 after it exits
        double fee2 = manager.collectFees(vehicle2);
        System.out.println("Fee collected for vehicle " + vehicle2.vehicleNumber + ": " + fee2);

        // Simulate vehicle 3 exiting the parking lot
        try {
            Thread.sleep(3000);  // Sleep for 3 seconds as a stand-in for 3 hours
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        // Collect fees for vehicle3 after it exits
        double fee3 = manager.collectFees(vehicle3);
        System.out.println("Fee collected for vehicle " + vehicle3.vehicleNumber + ": " + fee3);
    }
}
