import java.time.LocalDate;
import java.util.List;

public class LibraryCard {
    String id;
    List<Book> booksIssued;
    LocalDate expiryDate;


    public LibraryCard(String id, List<Book> booksIssued, LocalDate expiryDate) {
        this.id = id;
        this.booksIssued = booksIssued;
        this.expiryDate = null;
    }
}
