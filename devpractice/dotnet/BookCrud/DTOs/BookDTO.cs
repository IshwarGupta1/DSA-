using BookCrud.Models;
using System.ComponentModel.DataAnnotations;

namespace BookCrud.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }  // Primary Key
        public string Title { get; set; }

        public string Author { get; set; }
        public decimal Price { get; set; }

        [Required]
        public int categoryId { get; set; }
        public Category Category { get; set; }
    }
}
