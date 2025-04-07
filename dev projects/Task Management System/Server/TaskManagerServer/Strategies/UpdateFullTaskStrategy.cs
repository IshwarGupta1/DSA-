using TaskManagerServer.Entities;

namespace TaskManagerServer.Strategies
{
    public class UpdateFullTaskStrategy : ITaskUpdateStrategy
    {
        public void UpdateTask(TaskEntity existingTask, TaskEntity newTask)
        {
            existingTask.Title = newTask.Title;
            existingTask.Description = newTask.Description;
            existingTask.TaskStatus = newTask.TaskStatus;
            existingTask.DueDate = newTask.DueDate;
        }
    }
}
