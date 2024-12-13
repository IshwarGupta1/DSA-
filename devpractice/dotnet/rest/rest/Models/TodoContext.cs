using EFCore.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace rest.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {

        }
        public DbSet<Item> Item { get; set; }
    }
}
