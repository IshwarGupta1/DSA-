using BookCrud.Models;
using BookCrud.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCrud.Controllers
{
    [ApiController]
    [Route("api/categories/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetCategories()
        {
            return Ok(categoryService.GetCategories());
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            try
            {
                return Ok(categoryService.GetCategory(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            categoryService.CreateCategory(category);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            try
            {
                categoryService.UpdateCategory(id, category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                categoryService.DeleteCategory(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
