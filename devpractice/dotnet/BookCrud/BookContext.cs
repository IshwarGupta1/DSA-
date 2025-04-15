using BookCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCrud
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
               .HasMany(b => b.Books)
               .WithOne(c => c.Category)
               .HasForeignKey(c => c.Id);
        }
    }
}
