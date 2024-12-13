using rest.DTO;

namespace rest.Service
{
    public interface IToDoService
    {
        public Task<IEnumerable<ItemDTO>> getAllItemsAsync();
        public Task<ItemDTO> getItemByIdAsync(int id);
        public Task AddItemAsync(ItemDTO item);
        public Task DeleteItemAsync(int id);
        public Task UpdateItemAsync(int id, ItemDTO item);
    }
}
