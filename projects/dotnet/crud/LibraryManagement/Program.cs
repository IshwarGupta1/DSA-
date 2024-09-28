// See https://aka.ms/new-console-template for more information
using LibraryManagement;

Console.WriteLine("Hello, World!");
var books = new List<Book>
            {
                new Book( 1, "The Great Gatsby", DateTime.MinValue ), // Initial issuedDate is a placeholder
                new Book(2, "1984", DateTime.MinValue),
                new Book(3, "To Kill a Mockingbird", DateTime.MinValue )
            };

var members = new List<Member>();

// Create library instance
var library = new Library(books, members);

// Register members
var member1 = new Member("Alice", new LibraryCard(), 0);
library.registerMember(member1);

var member2 = new Member("Bob", new LibraryCard(), 0);
library.registerMember(member2);

// Issue books
library.issueBook(books[0], member1); // Alice borrows "The Great Gatsby"
library.issueBook(books[1], member1); // Alice borrows "1984"
library.issueBook(books[0], member2); // Bob tries to borrow "The Great Gatsby"

// Return books
library.returnBook(books[0], member1); // Alice returns "The Great Gatsby"
library.returnBook(books[0], member2); // Bob tries to return a book he doesn't have

// Renew library card
library.RenewLibraryCard(member1, 6); // Renew Alice's library card

// Clear fines
library.clearFine(member1); // Clear fines for Alice (if any)

// Simulate overdue book return
books[1].issuedDate = DateTime.UtcNow.AddDays(-20); // Simulate "1984" issued 20 days ago
library.returnBook(books[1], member1); // Alice returns "1984" and incurs a fine

// Print final member state
Console.WriteLine($"Final fine for {member1.Name}: {member1.Fine}");
Console.WriteLine($"Final fine for {member2.Name}: {member2.Fine}");

Console.ReadLine();
