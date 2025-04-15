using System.ComponentModel.DataAnnotations;

namespace BookCrud.Models
{
    public class Book
    {
        public int Id { get; set; }  // Primary Key

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title Must be between 3 to 100")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(50,ErrorMessage = "Author Name must be of max 50")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(1,10000,ErrorMessage = "Price must be between 1 to 10000")]
        public decimal Price { get; set; }

        [Required]
        public int categoryId { get; set; }
        public Category Category { get; set; }

        //[CustomAttribute]
        //public DateTime pubDate { get; set; }
    }
}
