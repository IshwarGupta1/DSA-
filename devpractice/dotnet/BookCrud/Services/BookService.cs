using BookCrud.Models;

namespace BookCrud.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _context;
        public BookService(BookContext context)
        {
            _context = context;
        }

        public void createBook(string title, string author, decimal price)
        {
            var book = new Book { Id = _context.Books.Count()+1, Title = title, Author = author, Price = price };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void deleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new Exception("book not found");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Book getBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new Exception("book not found");
            }
            return book;
        }

        public List<Book> getBooks()
        {
            return _context.Books.ToList();
        }

        public void updateBook(int id, Book book)
        {
            var bookPresent = _context.Books.FirstOrDefault(b => b.Id == id);
           
            if (bookPresent == null)
            {
                throw new Exception("book not found");
            }
            bookPresent.Author = book.Author;
            bookPresent.Price = book.Price;
            bookPresent.Title = book.Title;
            _context.SaveChanges();
            return;

        }
    }
}
