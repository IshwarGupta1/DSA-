package org.example;

import java.util.*;

public class ParkingLot {
    int numberofFloors;
    int numberofSpots;

    ArrayList<ArrayList<ParkingSpot>> spotList = new ArrayList<>();

    public ParkingLot(int numberofFloors, int numberofSpots) {
        this.numberofFloors = numberofFloors;
        this.numberofSpots = numberofSpots;
    }

    public int getNumberofFloors() {
        return numberofFloors;
    }

    public int getNumberofSpots() {
        return numberofSpots;
    }

    public ArrayList<ArrayList<ParkingSpot>> getSpotList() {
        return this.spotList;
    }

    public void setSpotList() {
        int numberofBikeParkingSpots = (this.numberofSpots*30)/100;
        int numberofCarParkingSpots = (this.numberofSpots*70)/100;
        for(int i = 0; i < this.numberofFloors ; i++)
        {
            ArrayList<ParkingSpot> parkingSpots = new ArrayList<>();
            for(int j = 0; j < numberofBikeParkingSpots ; j++)
            {
                ParkingSpot spot = new ParkingSpot();
                spot.setParkingSpotID("Bike " + j+1 + i+1);
                spot.setSpotType(VehicleType.Bike);
                spot.setFloorNumber(i+1);
                parkingSpots.add(spot);
            }
            for(int j = numberofBikeParkingSpots; j < numberofBikeParkingSpots+numberofCarParkingSpots ; j++)
            {
                ParkingSpot spot = new ParkingSpot();
                spot.setParkingSpotID("Car " + j+1 + i+1);
                spot.setSpotType(VehicleType.Car);
                spot.setFloorNumber(i+1);
                parkingSpots.add(spot);
            }
            this.spotList.add(parkingSpots);
        }
    }
}
