package Entities;
import java.util.*;
import java.util.stream.Collectors;

public class ParkingLot {
    private List<ParkingSpot> parkingSpots;
    public ParkingLot(List<ParkingSpot> parkingSpots)
    {
        this.parkingSpots = parkingSpots;
    }

    public double parkingSpotFees(ParkingSpot parkingSpot)
    {
        if (parkingSpot.vehicleType == null || parkingSpot.vehicleSize == null) {
            throw new IllegalArgumentException("Parking spot vehicle type or size is not set.");
        }

        return switch (parkingSpot.vehicleType) {
            case TwoWheeler -> switch (parkingSpot.vehicleSize) {
                case Small -> 10.0; // bicycle
                case Medium -> 12.5; // bike
                default -> throw new IllegalArgumentException("Unsupported vehicle size for Two Wheeler");
            };
            case Handicapped -> switch (parkingSpot.vehicleSize) {
                case Small -> 5.0;
                case Medium -> 7.5;
                default -> throw new IllegalArgumentException("Unsupported vehicle size for Handicapped");
            };
            case FourWheeler -> switch (parkingSpot.vehicleSize) {
                case Small -> 15.0; // 4 seater
                case Medium -> 20.0; // 6 seater
                case Large -> 25.0;  // mini bus
                default -> throw new IllegalArgumentException("Unsupported vehicle size for Four Wheeler");
            };
            default -> throw new IllegalArgumentException("Unsupported vehicle type");
        };
    }

    public List<ParkingSpot> availableParkingSpots(Vehicle vehicle)
    {
        List<ParkingSpot> availableSpots = parkingSpots.stream().filter(spot -> spot.status == Status.Free && spot.vehicleType==vehicle.type && spot.vehicleSize == vehicle.size).collect(Collectors.toList());
        return availableSpots;
    }
}
