import java.util.ArrayList;
import java.util.List;
public class Audi {
    Movie movie;
    List<Seat> seats;

    public Audi(Movie movie, List<Seat> seats) {
        this.movie = new Movie(new String(), new ArrayList(), new String(), new ArrayList(), new ArrayList<>());
        this.seats = seats;
    }
}
