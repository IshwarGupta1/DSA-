using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Library
    {
        public List<Book> books { get; set; }
        public List<Member> members { get; set; }
        public Library(List<Book> books, List<Member> members)
        {
            this.books = books;
            this.members = members;
        }

        public void registerMember(Member member)
        {
            if (members.Contains(member))
                Console.WriteLine("member already exists");
            var card = new LibraryCard(123, DateTime.UtcNow.AddMonths(6), new List<Book>());
            member.Card = card;
            members.Add(member);
            member.Fine = 0;
            Console.WriteLine("Member added");
        }

        public void issueBook(Book book, Member member)
        {
            if (!members.Contains(member))
                Console.WriteLine("you are not a member of this Library");
            var card = member.Card;
            if (card == null)
            {
                Console.WriteLine("Member does not have a library card.");
                return;
            }
            if (card.ExpiryDate > DateTime.UtcNow)
                Console.WriteLine("your LibraryCard has expired.Please renew.");
            var bookList = member.Card.BookEntries;
            if (!bookList.Contains(book))
            {
                Console.WriteLine("Book Already Registered to you");
            }
            if (!books.Contains(book))
            {
                Console.WriteLine("Book not available");
            }
            book.issuedDate = DateTime.UtcNow;
            member.Card.addBookEntry(book, DateTime.UtcNow);
            books.Remove(book);
            Console.WriteLine($"Book issued to {member.Name} at  {DateTime.UtcNow}");
        }

        public void returnBook(Book book, Member member)
        {
            if (!members.Contains(member))
                Console.WriteLine("you are not a member of this Library");
            var card = member.Card;
            if (card == null)
            {
                Console.WriteLine("Member does not have a library card.");
                return;
            }
            if (card.ExpiryDate > DateTime.UtcNow)
                Console.WriteLine("your LibraryCard has expired.Please renew.");

            if (!member.Card.BookEntries.Contains(book))
            {
                Console.WriteLine("You do not have this book issued.");
                return;
            }
            if (book.issuedDate.AddDays(15) > DateTime.UtcNow)
            {
                member.Fine = 10 * (DateTime.UtcNow - book.issuedDate.AddDays(15)).TotalDays;
                Console.WriteLine($"You are late. You have to pay fine {member.Fine}");
            }
            member.Card.removeBookEntry(book);
            books.Add(book);
        }

        public void RenewLibraryCard(Member member, int months)
        {
            if (!members.Contains(member))
                Console.WriteLine("you are not a member of this Library");
            var card = member.Card;
            if (card == null)
            {
                Console.WriteLine("Member does not have a library card.");
                return;
            }
            if (member.Fine > 0)
            {
                Console.WriteLine("First Clear the fine due ");
            }
            if (card.ExpiryDate > DateTime.UtcNow)
            {
                card.ExpiryDate = DateTime.UtcNow.AddMonths(months);
                Console.WriteLine("Card renewed");
                var renewalfees = 20 * months;
                Console.WriteLine($"Pay renewal fees {renewalfees}");
            }
            else
                Console.WriteLine("card not expired");
        }

        public void clearFine(Member member)
        {
            if (!members.Contains(member))
                Console.WriteLine("you are not a member of this Library");
            var card = member.Card;
            if (card == null)
            {
                Console.WriteLine("Member does not have a library card.");
                return;
            }
            if (card.ExpiryDate > DateTime.UtcNow)
                Console.WriteLine("your LibraryCard has expired.Please renew.");

            var fine = member.Fine;
            if (fine > 0)
            {
                Console.WriteLine($"Pay fine {fine}");
                member.Fine = 0;
            }
            else
                Console.WriteLine("No Fine Dues");
        }
    }
}
