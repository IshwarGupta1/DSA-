using Microsoft.EntityFrameworkCore;
using TaskManagerServer.Data;
using TaskManagerServer.Entities;
using TaskManagerServer.Strategies;

namespace TaskManagerServer.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDataContext _context;

        public TaskRepository(TaskDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task AddTask(TaskEntity taskEntity)
        {
            await _context.Tasks.AddAsync(taskEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(int taskId, TaskEntity newTask, ITaskUpdateStrategy updateStrategy)
        {
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskId);

            if (existingTask == null)
                throw new InvalidOperationException("Task Not Found");

            updateStrategy.UpdateTask(existingTask, newTask);

            _context.SaveChanges();
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var taskEntity = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskId);

            if (taskEntity == null)
                throw new InvalidOperationException("Task Not Found");

            _context.Tasks.Remove(taskEntity);
            _context.SaveChanges();
        }
    }
}
