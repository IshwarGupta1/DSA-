import java.util.List;

public class Movie {
    String movieName;
    List<Genre> Genre;
    String releaseDate;
    List<String> runningTime;
    List<Language> languageList;

    public Movie(String movieName, List<Genre> genre, String releaseDate, List<String> runningTime, List<Language> languageList) {
        this.movieName = movieName;
        Genre = genre;
        this.releaseDate = releaseDate;
        this.runningTime = runningTime;
        this.languageList = languageList;
    }
}
