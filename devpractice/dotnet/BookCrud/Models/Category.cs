using System.ComponentModel.DataAnnotations;

namespace BookCrud.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category needs to have a name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Range must be between 5 and 20")]
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
