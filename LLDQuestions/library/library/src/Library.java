import java.time.LocalDate;
import java.util.List;

public class Library {
    public List<Book> books;
    public List<Member> members;
    public Librarian librarian;
    public double membershipFees = 100;
    public double lateFine = 10;
    public Library(List<Book> books, List<Member> members, Librarian librarian)
    {
        this.books = books;
        this.members = members;
        this.librarian = librarian;
    }

    public void addBook(Book book)
    {
        books.add(book);
        return;
    }

    public void removeBook(Book book)
    {
        if(!books.contains(book))
             new Exception("book does not exist");
        books.remove(book);
        return;
    }

}
