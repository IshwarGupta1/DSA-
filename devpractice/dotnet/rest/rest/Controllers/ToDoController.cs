using Microsoft.AspNetCore.Mvc;
using rest.DTO;
using rest.Service;

namespace rest.Controllers
{
    [Route("todo/")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var itemList = await _toDoService.getAllItemsAsync();
            return Ok(itemList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(int id)
        {
            var item = await _toDoService.getItemByIdAsync(id);
            return Ok(item);
        }

        // POST: ToDoController/Create
        [HttpPost]
        
        public async Task<ActionResult> CreateItem(ItemDTO item)
        {
            await _toDoService.AddItemAsync(item);
            return NoContent();
        }

        // GET: ToDoController/Edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult> EditItem(int id, ItemDTO item)
        {
            await _toDoService.UpdateItemAsync(id, item);
            return NoContent();
        }

        // GET: ToDoController/Delete/5
        public async Task<ActionResult> DeleteItem(int id)
        {
            await _toDoService.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
