using BookCrud.Models;

namespace BookCrud.Services
{
    public interface IBookService
    {
        public List<Book> getBooks();
        public Book getBook(int id);
        public void updateBook(int id, Book book);
        public void deleteBook(int id);
        public void createBook(string title, string Author, decimal price);
    }
}