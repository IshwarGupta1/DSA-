using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Library
    {
        private List<Book> _books = new List<Book>();
        private Dictionary<string, Book> _booksDict = new Dictionary<string, Book>();
        private HashSet<string> _genreList = new HashSet<string>();
        private Stack<Book> _booksStack = new Stack<Book>();

        public void addBook(Book book)
        {
            _books.Add(book);
            _booksDict.Add(book.ISBN, book);
            _genreList.Add(book.ISBN);
            _booksStack.Push(book);
        }

        public void searchByISBN(string ISBN)
        {
            var book = _booksDict.GetValueOrDefault(ISBN);
            Console.WriteLine(book.Title);
        }

        public void DisplayGenres()
        {
            Console.WriteLine("Unique genres:");
            foreach (var genre in _genreList)
                Console.WriteLine($"- {genre}");
        }

        public void removeBook()
        {
            if(_booksStack.Count > 0)
            {
                var book = _booksStack.Peek();
                _booksStack.Pop();
            }
            Console.WriteLine("Nothing to remove");
        }



    }
}
