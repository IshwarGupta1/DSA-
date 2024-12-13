package org.example;

import java.util.ArrayList;
import java.util.List;

public class parkingSystem {
    ParkingLot parkingLot;
    public parkingSystem(ParkingLot parkingLot)
    {
        this.parkingLot = parkingLot;
    }
    public void createParkingLot(int floors, int numberofSlotsperfloor)
    {
        parkingLot.floors = floors;
        parkingLot.numberofSlotsperfloor = numberofSlotsperfloor;
        List<List<ParkingSlot>> parkingLotList = new ArrayList<>();
        for(int i=1;i<=floors;i++)
        {
            List<ParkingSlot> parkingLotperfloor = new ArrayList<ParkingSlot>();
            ParkingSlot truckParkingSlot = new ParkingSlot(VehicleType.Truck, "1" ,i, Status.Available);
            ParkingSlot firstCarParkingSlot = new ParkingSlot(VehicleType.Car, "2" ,i, Status.Available);
            ParkingSlot secondCarParkingSlot = new ParkingSlot(VehicleType.Car, "3" ,i, Status.Available);
            parkingLotperfloor.add(truckParkingSlot);
            parkingLotperfloor.add(firstCarParkingSlot);
            parkingLotperfloor.add(secondCarParkingSlot);
            for(int j=3; j<=numberofSlotsperfloor;j++)
            {
                ParkingSlot parkinglot = new ParkingSlot(VehicleType.Bike, Integer.toString(j), i, Status.Available);
                parkingLotperfloor.add(parkinglot);
            }
            parkingLotList.add(parkingLotperfloor);
        }
        parkingLot.parkingSlotList = parkingLotList;
        System.out.println("Parking lot created - Details are : " + parkingLot.parkingLotId + " with "+ floors + " floors");
    }

    public void addfloor(int numberofSlotsperFloor)
    {
        int currentNumberofFloors = parkingLot.floors;
        int updatedNumberofFloors = currentNumberofFloors + 1;
        List<ParkingSlot> parkingLotList = new ArrayList<>();
        ParkingSlot truckParkingSlot = new ParkingSlot(VehicleType.Truck, "1" ,updatedNumberofFloors, Status.Available);
        ParkingSlot firstCarParkingSlot = new ParkingSlot(VehicleType.Car, "2" ,updatedNumberofFloors, Status.Available);
        ParkingSlot secondCarParkingSlot = new ParkingSlot(VehicleType.Car, "3" ,updatedNumberofFloors, Status.Available);
        parkingLotList.add(truckParkingSlot);
        parkingLotList.add(firstCarParkingSlot);
        parkingLotList.add(secondCarParkingSlot);
        for(int j=3; j<=numberofSlotsperFloor;j++)
        {
            ParkingSlot parkinglot = new ParkingSlot(VehicleType.Bike, Integer.toString(j), updatedNumberofFloors, Status.Available);
            parkingLotList.add(parkinglot);
        }
        parkingLot.parkingSlotList.add(parkingLotList);
    }

    public void addParkingSlot(int floor, ParkingSlot parkingSlot)
    {
        List<ParkingSlot> parkingSlotList = parkingLot.parkingSlotList.get(floor);
        int numberofSlots = parkingSlotList.size();
        parkingSlot.slotNumber = Integer.toString(numberofSlots + 1);
        parkingSlotList.add(parkingSlot);
    }

    public void parkVehicle(Vehicle vehicle)
    {
        int numberofFloors = parkingLot.floors;
        for(int i=0;i<numberofFloors;i++)
        {
            List<ParkingSlot> parkingSlotList = parkingLot.parkingSlotList.get(i);
            for(int j=0;j<parkingSlotList.size();j++)
            {
                if(parkingSlotList.get(j).slotType == vehicle.vehicleType && parkingSlotList.get(j).status == Status.Available)
                {
                    String ticket = parkingLot.parkingLotId + parkingSlotList.get(j).floor + j;
                    vehicle.ticket = ticket;
                    parkingSlotList.get(j).status = Status.Unavailable;
                    return;
                }
            }
        }

            System.out.println("No slots available");

    }

    public void unParkVehicle(Vehicle vehicle)
    {
        String ticket = vehicle.ticket;
        int floorNum = ticket.charAt(6) - '0';
        int slotNum = ticket.charAt(7) - '0';
        List<ParkingSlot> parkingSlotlist = parkingLot.parkingSlotList.get(floorNum);
        ParkingSlot parkingSlot = parkingSlotlist.get(slotNum);
        parkingSlot.status = Status.Available;
    }
}
