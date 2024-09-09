using Microsoft.EntityFrameworkCore;
using ScrumPoker.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ScrumPoker.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasKey(c => c.CardId); // Primary key

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.User)
                .WithMany() // Assuming User has no collection of votes
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Session)
                .WithMany(s => s.Votes)
                .HasForeignKey(v => v.SessionId);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Card)
                .WithMany()
                .HasForeignKey(v => v.CardId);
        }
    }

}
