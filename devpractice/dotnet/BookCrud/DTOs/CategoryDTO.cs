using BookCrud.Models;
using System.ComponentModel.DataAnnotations;

namespace BookCrud.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
