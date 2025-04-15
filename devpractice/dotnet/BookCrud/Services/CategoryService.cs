using BookCrud.Models;

namespace BookCrud.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BookContext _context;
        public CategoryService(BookContext context)
        {
            _context = context;
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null)
            {
                throw new Exception("category not found");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                throw new Exception("category not found");
            }
            return category;
        }

        public void UpdateCategory(int id, Category category)
        {
            var oldcategory = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (oldcategory == null)
            {
                throw new Exception("category not found");
            }
            oldcategory.Name = category.Name;
            oldcategory.Books = category.Books;
            _context.SaveChanges();
        }
    }
}
