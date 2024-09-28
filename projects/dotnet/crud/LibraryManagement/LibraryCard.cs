using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class LibraryCard
    {
        public int Id { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<Book> BookEntries { get; set; }
        public LibraryCard(int id, DateTime expiryDate, List<Book> bookEntries)
        {
            Id = id;
            ExpiryDate = expiryDate;
            BookEntries = bookEntries;
        }

        public LibraryCard()
        {
        }

        public void addBookEntry(Book book, DateTime dateTime)
        {
            if(BookEntries.Contains(book))
                Console.WriteLine($"You already have {book.Name} issued");
            BookEntries.Add(book);
            Console.WriteLine($"{book.Name} issued to you at {dateTime}");
        }

        public void removeBookEntry(Book book)
        {
            if (!BookEntries.Contains(book))
                Console.WriteLine($"You don't have {book.Name} issued");
            BookEntries.Remove(book);
            Console.WriteLine($"{book.Name} returned.");
        }
    }
}
