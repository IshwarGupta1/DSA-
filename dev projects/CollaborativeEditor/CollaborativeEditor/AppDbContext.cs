using CollaborativeEditor.Models;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeEditor.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<FileMetadata> FileMetadata { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentVersion> DocumentVersions { get; set; }
        
    }
}
