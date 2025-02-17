using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        
        public Book(string ISBN, string Author, string Title, string Genre)
        {
            this.ISBN = ISBN;
            this.Author = Author;
            this.Title = Title;
            this.Genre = Genre;
        }
    }
}
