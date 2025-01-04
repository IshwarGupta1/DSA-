﻿using Microsoft.EntityFrameworkCore;
using ScrumPoker.Models;

namespace ScrumPoker
{
    public class DataContext:DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DataContext(DbContextOptions<DataContext> options):base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
