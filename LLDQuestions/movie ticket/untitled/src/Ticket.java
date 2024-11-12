public class Ticket {
    Movie movie;
    Seat seat;
    String time;

    public Ticket(Movie movie, Seat seat, String time) {
        this.movie = movie;
        this.seat = seat;
        this.time = time;
    }
}
