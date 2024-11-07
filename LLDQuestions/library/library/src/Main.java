import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        // Step 1: Create a list of books
        List<Book> books = new ArrayList<>();
        books.add(new Book("B001", "Java Basics", "John Doe", "2022-01-01", Status.Available, LocalDate.now()));
        books.add(new Book("B002", "Advanced Java", "Jane Smith", "2022-03-15", Status.Available, LocalDate.now()));
        books.add(new Book("B003", "Data Structures", "Alan Turing", "2021-05-20", Status.Available, LocalDate.now()));

        // Step 2: Create a Library and assign the books to it
        Library library = new Library(books, new ArrayList<>(), null);

        // Step 3: Create a Librarian
        Librarian librarian = new Librarian("L001", "Alice", library);
        library.librarian = librarian; // Assign librarian to library

        // Step 4: Create Members and add them to the library
        Member member1 = new Member("M001", "Bob");
        member1.joinLibrary(librarian, "Cash");  // Bob joins with Cash payment

        Member member2 = new Member("M002", "Charlie");
        member2.joinLibrary(librarian, "UPI");  // Charlie joins with UPI payment

        // Step 5: Issue books to members
        try {
            member1.borrowBook(librarian, books.get(0));
            member2.borrowBook(librarian, books.get(1));
           
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }

        // Step 6: Member tries to borrow another book (should fail)
        try {
            librarian.issueBook(member1, books.get(2));  // Bob tries to borrow "Data Structures"
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());  // Expected: Cannot have more than 5 books at a time
        }

        // Step 7: Return or Renew books
        try {
            member1.returnOrRenewBook(librarian, books.get(0), false, "Cash");  // Bob returns "Java Basics"
            librarian.issueBook(member1, books.get(2));  // Bob borrows "Data Structures"
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }

        // Step 8: Try to renew a book
        try {
            member2.returnOrRenewBook(librarian, books.get(1), true, "UPI");  // Charlie renews "Advanced Java"
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }

        // Step 9: Calculate overdue fees (simulated by skipping a few days)
        try {
            Thread.sleep(5000);  // Simulate some delay (e.g., 5 seconds as an example for demo)
            member1.returnOrRenewBook(librarian, books.get(2), false, "Cash");  // Return "Data Structures" late
        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
