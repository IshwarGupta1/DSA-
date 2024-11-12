public class Seat {
    String SeatNumber;
    Double ticketCost;
    Status status;

    public Seat(String seatNumber, Double ticketCost, Status status) {
        SeatNumber = seatNumber;
        this.ticketCost = ticketCost;
        this.status = status;
    }
}
