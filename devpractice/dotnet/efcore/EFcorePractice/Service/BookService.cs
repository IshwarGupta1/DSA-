namespace EFcorePractice.Service
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;
        public BookService(DataContext context)
        {
            _context = context;
        }

        public void addBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void deleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void findBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public void updateBook(string bookName, int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            book.Title = bookName;
            _context.SaveChanges();
        }
    }
}
