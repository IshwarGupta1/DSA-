import java.util.*;
public class User {
    String name;
    String userId;
    String password;

    public User(String name, String password) {
        this.name = name;
        this.userId = new String();
        this.password = password;
    }

    public void register(BookingPlatform platform)
    {
        platform.registerUser(this);
    }

    public void login(BookingPlatform platform, String password)
    {
        platform.authenticateUser(this, password);
    }

    public void searchMovies(BookingPlatform platform, String type, String value)
    {
        platform.search(this, type, value);
    }

    public List<Ticket> bookMovie(BookingPlatform platform, Movie movie, Theatre theatre, String runningTime, Double payment, int numberofTickets)
    {
        return platform.bookTicket(this, movie, theatre, runningTime, payment, numberofTickets);
    }
}
