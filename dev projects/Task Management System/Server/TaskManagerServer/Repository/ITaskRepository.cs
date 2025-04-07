using TaskManagerServer.Entities;
using TaskManagerServer.Strategies;

namespace TaskManagerServer.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> GetAllTasks();
        Task AddTask(TaskEntity taskEntity);
        Task UpdateTaskAsync(int taskId, TaskEntity newTask, ITaskUpdateStrategy updateStrategy);
        Task DeleteTaskAsync(int taskId);
    }
}
