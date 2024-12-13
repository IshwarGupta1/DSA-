package org.example;

import java.util.List;

public class ParkingLot {
    List<List<ParkingSlot>> parkingSlotList;
    int numberofSlotsperfloor;
    int floors;
    String parkingLotId = "PR1234";


    public ParkingLot(int numberofSlotsperfloor, int floors) {
        this.numberofSlotsperfloor = numberofSlotsperfloor;
        this.floors = floors;
    }
}
