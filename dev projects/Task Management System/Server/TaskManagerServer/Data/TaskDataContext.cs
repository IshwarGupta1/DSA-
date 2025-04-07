using Microsoft.EntityFrameworkCore;
using TaskManagerServer.Entities;

namespace TaskManagerServer.Data
{
    public class TaskDataContext : DbContext
    {
        public TaskDataContext(DbContextOptions<TaskDataContext> options) : base(options)
        {

        }
        public DbSet<TaskEntity> Tasks { get; set; }

    }
}