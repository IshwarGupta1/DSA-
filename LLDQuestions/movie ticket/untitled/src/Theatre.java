import java.util.ArrayList;
import java.util.List;
public class Theatre {
    List<Movie> movies;
    String Location; //later on we can create an address model for this
    List<Audi> audi;

    public Theatre(String Location, List<Audi> audi) {
        this.Location = Location;
        this.movies = new ArrayList<>();
        this.audi = audi;
    }
}
