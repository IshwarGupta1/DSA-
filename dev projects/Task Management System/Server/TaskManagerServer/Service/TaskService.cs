using TaskManagerServer.DTOs;
using TaskManagerServer.Entities;
using TaskManagerServer.Repository;
using TaskManagerServer.Service;
using TaskManagerServer.Strategies;

namespace TaskManagerServer.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskEntityDTO>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();
            return tasks.Select(TaskMapper.MapToDTO);
        }

        public async Task AddTask(TaskEntityDTO taskDto)
        {
            var taskEntity = new TaskEntity
            {
                TaskId = taskDto.TaskId,
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                TaskStatus = taskDto.TaskStatus
            };

            await _taskRepository.AddTask(taskEntity);
        }

        public async Task UpdateTask(int taskId, TaskEntityDTO newTaskDto, ITaskUpdateStrategy updateStrategy)
        {
            var newTaskEntity = new TaskEntity
            {
                Title = newTaskDto.Title,
                Description = newTaskDto.Description,
                DueDate = newTaskDto.DueDate,
                TaskStatus = newTaskDto.TaskStatus
            };

            await Task.Run(() => _taskRepository.UpdateTaskAsync(taskId, newTaskEntity, updateStrategy));
        }

        public async Task DeleteTask(int taskId)
        {
            await Task.Run(() => _taskRepository.DeleteTaskAsync(taskId));
        }
    }
}
