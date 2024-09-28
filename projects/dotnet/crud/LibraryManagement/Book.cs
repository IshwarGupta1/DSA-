using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public DateTime issuedDate { get; set; }
        public Book(int BookId, string Name, DateTime issuedDate)
        {
            this.BookId = BookId;
            this.Name = Name;
            this.issuedDate = issuedDate;
        }
    }
}
