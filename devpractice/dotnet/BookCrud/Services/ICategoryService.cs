using BookCrud.Models;

namespace BookCrud.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
        void CreateCategory(Category category);
        void UpdateCategory(int id, Category category);
        void DeleteCategory(int id);
    }
}
