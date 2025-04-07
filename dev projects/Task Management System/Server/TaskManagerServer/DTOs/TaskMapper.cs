using TaskManagerServer.Entities;

namespace TaskManagerServer.DTOs
{
    public static class TaskMapper
    {
        public static TaskEntityDTO MapToDTO(TaskEntity taskEntity)
        {
            if (taskEntity == null) 
                return null;

            return new TaskEntityDTO
            {
                TaskId = taskEntity.TaskId,
                Title = taskEntity.Title,
                Description = taskEntity.Description,
                DueDate = taskEntity.DueDate,
                TaskStatus = taskEntity.TaskStatus
            };
        }
    }
}
