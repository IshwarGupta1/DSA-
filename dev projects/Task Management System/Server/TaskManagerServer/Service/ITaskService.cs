using TaskManagerServer.DTOs;
using TaskManagerServer.Strategies;

namespace TaskManagerServer.Service
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskEntityDTO>> GetAllTasks();
        Task AddTask(TaskEntityDTO taskDto);
        Task UpdateTask(int taskId, TaskEntityDTO newTaskDto, ITaskUpdateStrategy updateStrategy);
        Task DeleteTask(int taskId);
    }
}
