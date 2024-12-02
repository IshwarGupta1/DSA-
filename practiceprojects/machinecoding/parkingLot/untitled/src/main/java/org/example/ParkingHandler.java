package org.example;

import java.util.List;

public class ParkingHandler {

    parkingSystem parkingSystem;
    ParkingLot parkingLot;
    public ParkingHandler(parkingSystem parkingSystem)
    {
        this.parkingSystem = parkingSystem;
        this.parkingLot = parkingSystem.parkingLot;
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
