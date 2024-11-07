import java.time.LocalDate;

public class Book {
    String bookId;
    String name;
    String author;
    String publicationDate;
    Status status;
    LocalDate issuedDate;

    public Book(String bookId, String name, String author, String publicationDate, Status status, LocalDate issuedDate) {
        this.bookId = bookId;
        this.name = name;
        this.author = author;
        this.publicationDate = publicationDate;
        this.status = status;
        this.issuedDate = null;
    }
}

