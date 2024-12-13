using Microsoft.EntityFrameworkCore;
using rest.DTO;
using rest.Models;

namespace rest.Service
{
    public class ToDoService : IToDoService
    {
        private TodoContext _context;
        public ToDoService(TodoContext context)
        {
            _context = context;
        }
        public async Task AddItemAsync(ItemDTO item)
        {
            var newItem = new Item
            {
                isComplete = item.isComplete,
                itemName = item.itemName,
                itemId = item.itemId
            };
            await _context.AddAsync(newItem);
            _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var newItem = await _context.Item.FirstOrDefaultAsync(x => x.itemId == id);
            var itemDTO = new ItemDTO
            {
                itemId = newItem.itemId,
                isComplete = newItem.isComplete,
                itemName = newItem.itemName
            };
            _context.Remove(itemDTO);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemDTO>> getAllItemsAsync()
        {
            var itemList = await _context.Item.Select(x => new ItemDTO
            {
                isComplete = x.isComplete,
                itemId = x.itemId,
                itemName = x.itemName,
            }).ToListAsync();
            return itemList;
        }

        public async Task<ItemDTO> getItemByIdAsync(int id)
        {
            var item = await _context.Item.FirstOrDefaultAsync(x => x.itemId == id);
            var itemDTO = new ItemDTO
            {
                itemId = item.itemId,
                itemName = item.itemName,
                isComplete = item.isComplete
            };
            return itemDTO;
        }

        public async Task UpdateItemAsync(int id, ItemDTO item)
        {
            var newItem = await _context.Item.FirstOrDefaultAsync(x => x.itemId == id);
            newItem.itemName = item.itemName;
            newItem.isComplete = item.isComplete;
            _context.SaveChangesAsync();
        }
    }
}
