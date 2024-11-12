import java.time.LocalDate;
import java.time.ZoneId;
import java.time.temporal.ChronoUnit;
import java.util.*;

public class BookingPlatform {
    List<User> users;
    List<Theatre> theatres;
    List<Movie> movies;

    Map<User, Session> activeSessions;

    public BookingPlatform(List<User> users, List<Theatre> theatres, List<Movie> movies) {
        this.users = users;
        this.theatres = theatres;
        this.movies = movies;
        this.activeSessions = new HashMap<>();
    }

    public void addMovie(Movie movie, List<String> runningTimes)
    {
        movies.add(movie);
    }

    public void removeMovie(Movie movie)
    {
        if(!movies.contains(movie))
            new Exception("movie is not in the system");
        Date releaseDate = new Date(movie.releaseDate);
        LocalDate dateToCheck = releaseDate.toInstant().atZone(ZoneId.systemDefault()).toLocalDate();
        LocalDate fourWeeksAgo = LocalDate.now().minus(4, ChronoUnit.WEEKS);
        if (dateToCheck.isBefore(fourWeeksAgo)) {
            movies.remove(movie);
        }
    }

    public void AddTheatre(Theatre theatre)
    {
        theatre.movies = movies;
        for(int i=0;i<theatre.movies.size();i++)
        {
            theatre.audi.get(i).movie = theatre.movies.get(i);
        }
        if(theatre.audi.size()>theatre.movies.size())
        {
            int n = theatre.audi.size() - theatre.movies.size();
            for(int i=0;i<n;i++)
            {
                theatre.audi.get(n+i).movie = theatre.movies.get(i);
            }
        }
        theatres.add(theatre);
    }
    public void registerUser(User user) {
        if (users.contains(user))
            new Exception("User already has an account");
        user.userId = user.name + users.size();
        users.add(user);
        System.out.println("User has been registered");
    }

    public void authenticateUser(User user, String password) {
        if (activeSessions.containsKey(user) && activeSessions.get(user).isSessionActive()) {
            System.out.println("User already authenticated for this session.");
            return;
        }

        Session newSession = new Session(user);
        newSession.authenticate(password);
        activeSessions.put(user, newSession);
    }

    public void search(User user, String type, String value)
    {
        if (!activeSessions.containsKey(user) || !activeSessions.get(user).isSessionActive()) {
            System.out.println("please login again");
            return;
        }
        switch (type)
        {
            case "Genre" : searchByGenre(value);
            case "Name" : searchByName(value);
            case "Date" : searchByDate(value);
            case "Language" : searchByLanguage(value);
            case "" : giveAllMoviesList();
        }
    }

    public List<Ticket> bookTicket(User user, Movie movie, Theatre theatre, String runningTime, Double payment, int numberofTickets)
    {
        if (!activeSessions.containsKey(user) || !activeSessions.get(user).isSessionActive()) {
            throw new RuntimeException("please login again");
        }
        if(!theatre.movies.contains(movie))
            throw new RuntimeException("movie not available");
        List<Audi> audis = new ArrayList<>();
        List<Seat> seatsAvailable = new ArrayList<>();
        for(int i=0;i<theatre.audi.size();i++)
        {
            if(theatre.audi.get(i).movie.equals(movie) && theatre.audi.get(i).movie.runningTime.equals(runningTime))
                audis.add(theatre.audi.get(i));
        }
        for(int i=0;i<audis.size();i++)
        {
            for(int j=0;j<audis.get(i).seats.size();j++)
            {
                if(audis.get(i).seats.get(j).status.equals(Status.Available))
                    seatsAvailable.add(audis.get(i).seats.get(j));
            }
        }
        if(seatsAvailable.size()<numberofTickets)
            throw new RuntimeException("these many seats not available");
        var ticketCost = seatsAvailable.get(0).ticketCost;
        if(payment < ticketCost* numberofTickets)
            System.out.println("please pay "+ ((ticketCost* numberofTickets) - payment) + " extra");
        List<Ticket> tickets = new ArrayList<>();
        for(int i=0;i<numberofTickets;i++)
        {
            Ticket ticket = new Ticket(movie,seatsAvailable.get(i), runningTime );
            seatsAvailable.get(i).status = Status.Booked;
            tickets.add(ticket);
        }
        //for payment I will do strategy pattern for diff types of payment
        return tickets;
    }

    //for ticket cancellation I will create a method to check if it can be cancelled if ticket is cancelled before 2 hours of movie start then only

    private void searchByGenre(String Genre)
    {
        for(int i=0;i<movies.size();i++)
        {
            if(movies.get(i).Genre.contains(Genre.valueOf(Genre)))
                System.out.println(movies.get(i));
        }
    }

    private void searchByName(String name)
    {
        for(int i=0;i<movies.size();i++)
        {
            if(movies.get(i).movieName.equals(name))
            System.out.println(movies.get(i));
        }
    }

    private void searchByDate(String date)
    {
        for(int i=0;i<movies.size();i++)
        {
            if(movies.get(i).releaseDate.equals(date))
                System.out.println(movies.get(i));
        }
    }

    private void searchByLanguage(String Language)
    {
        for(int i=0;i<movies.size();i++)
        {
            if(movies.get(i).languageList.contains(Language.valueOf(Language)))
                System.out.println(movies.get(i));
        }
    }

    private void giveAllMoviesList()
    {
        for(int i=0;i<movies.size();i++)
        {
            System.out.println(movies.get(i));
        }
    }


}
