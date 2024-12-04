package org.example;

import java.time.Duration;
import java.time.LocalDateTime;
import java.util.*;

public class ParkingManager {
    ParkingLot parkingLot;
    HashMap<VehicleType, Integer> parkingCharge;
    PaymentManager paymentManager = new PaymentManager();

    public ParkingManager(ParkingLot parkingLot, HashMap<VehicleType, Integer> parkingCharge) {
        this.parkingLot = parkingLot;
        this.parkingCharge = parkingCharge;
    }

    public ParkingLot getParkingLot() {
        return parkingLot;
    }

    public void parkVehicle(Vehicle vehicle)
    {
        ArrayList<ArrayList<ParkingSpot>> parkingLotList = parkingLot.getSpotList();
        int numberofFloors = parkingLot.getNumberofFloors();
        int numberofSpots = parkingLot.getNumberofSpots();
        VehicleType vehicleType = vehicle.getVehicleType();

        for(int i=0; i< numberofFloors ; i++)
        {
            for(int j=0 ; j<numberofSpots ;j++)
            {
                if(parkingLotList.get(i).get(j).getSpotType() == vehicleType && parkingLotList.get(i).get(j).getStatus() == Status.Free)
                {
                    String vehicleString = vehicleType.toString();
                    String ticketId = vehicleString.charAt(0) + vehicle.vehicleNumber + (i+1) + (j+1);

                    LocalDateTime entryTime = LocalDateTime.now();
                    Ticket ticket = new Ticket(ticketId, entryTime, LocalDateTime.MAX);
                    parkingLotList.get(i).get(j).setStatus(Status.Parked);
                    vehicle.setTicket(ticket);
                    System.out.println("Vehicle "+vehicle.vehicleNumber + " parked at" + parkingLotList.get(i).get(j).getParkingSpotID());
                    return;
                }
            }
        }
        if(vehicle.getTicket().getEntryTime() == LocalDateTime.MIN)
        {
            System.out.println("No Spots Available");
            return;
        }
    }

    public void unParkVehicle(Ticket ticket, String modeofPayment)
    {
        String ticketId = ticket.getTicketId();
        ticket.setExitTime(LocalDateTime.now());
        char vehicleCharacter = ticketId.charAt(0);
        VehicleType vehicleType;
        switch (vehicleCharacter) {
            case 'C':
                vehicleType = VehicleType.Car;
                break;
            case 'B':
                vehicleType = VehicleType.Bike;
                break;
            default:
                throw new RuntimeException("Wrong Vehicle Type");
        }
        int charge = parkingCharge.get(vehicleType);
        int floor = Integer.parseInt(ticketId.substring(11, 12));
        int position = Integer.parseInt(ticketId.substring(12));
        parkingLot.spotList.get(floor).get(position).setStatus(Status.Free);
        Duration totalDuration = Duration.between(ticket.getEntryTime(),ticket.getExitTime());
        long hours = totalDuration.toHours();
        long minutes = totalDuration.toMinutes() % 60;
        long seconds = totalDuration.toSeconds()%3600;
        double totalCharge = (minutes * charge) + ((seconds * charge)/60);
        paymentManager.payCharge(totalCharge, modeofPayment);

    }
}
