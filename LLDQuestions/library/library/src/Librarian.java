import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.List;

public class Librarian {
    String id;
    String name;
    Library library;

    public Librarian(String id, String name, Library library) {
        this.id = id;
        this.name = name;
        this.library = library;
    }

    public void addMember(Member member, String paymentType) {
        if (library.members.contains(member)) {
            throw new IllegalArgumentException("Member already exists.");
        }

        // Create a new LibraryCard for the member
        LibraryCard card = new LibraryCard(member.memberId + member.memberName, List.of(), LocalDate.now().plusMonths(6));
        member.libraryCard = card;

        // Process payment
        Payment payment;
        switch (paymentType) {
            case "UPI" -> payment = new UPIPayment();
            case "CreditCard" -> payment = new CreditCardPayment();
            case "Cash" -> payment = new CashPayment();
            default -> throw new IllegalArgumentException("Invalid payment type");
        }
        payment.payAmount(library.membershipFees);

        // Add member to the library
        library.members.add(member);
    }

    public void removeMember(Member member) {
        if (!library.members.contains(member)) {
            throw new IllegalArgumentException("Member does not exist.");
        }
        library.members.remove(member);
    }

    public void issueBook(Member member, Book book) {
        if (member.libraryCard == null) {
            throw new IllegalStateException("No library card found for this member.");
        }
        if (!library.members.contains(member)) {
            throw new IllegalStateException("Not a member of the library.");
        }
        if (!library.books.contains(book)) {
            throw new IllegalArgumentException("Book is not in the library.");
        }
        if (book.status == Status.Unavailable) {
            throw new IllegalStateException("Book is currently unavailable.");
        }
        if (member.libraryCard.booksIssued.size() >= 5) {
            throw new IllegalStateException("Cannot have more than 5 books at a time.");
        }

        book.status = Status.Unavailable;
        book.issuedDate = LocalDate.now();
        member.libraryCard.booksIssued.add(book);
    }

    public void takeOrRenewBook(Member member, Book book, Boolean renew, String paymentType) {
        if (!library.members.contains(member)) {
            throw new IllegalStateException("Not a member of the library.");
        }
        if (!library.books.contains(book)) {
            throw new IllegalArgumentException("Book does not belong to the library.");
        }

        LocalDate issuedDate = book.issuedDate;
        long diffDays = ChronoUnit.DAYS.between(issuedDate, LocalDate.now());

        // Calculate and collect any fine if the book is overdue
        if (diffDays > 10) {
            double fine = (diffDays - 10) * library.lateFine;
            Payment payment;
            switch (paymentType) {
                case "UPI" -> payment = new UPIPayment();
                case "CreditCard" -> payment = new CreditCardPayment();
                case "Cash" -> payment = new CashPayment();
                default -> throw new IllegalArgumentException("Invalid payment type");
            }
            payment.payAmount(fine);
        }
        else
            System.out.println("no late fine charged");

        if (!renew) {
            book.status = Status.Available;
            book.issuedDate = null;
            member.libraryCard.booksIssued.remove(book);
        } else {
            book.issuedDate = LocalDate.now(); // Renew with a new issue date
        }
    }
}
