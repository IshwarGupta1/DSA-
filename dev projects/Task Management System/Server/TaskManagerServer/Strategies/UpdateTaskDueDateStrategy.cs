using TaskManagerServer.Entities;

namespace TaskManagerServer.Strategies
{
    public class UpdateDueDateStrategy : ITaskUpdateStrategy
    {
        public void UpdateTask(TaskEntity existingTask, TaskEntity newTask)
        {
            existingTask.DueDate = newTask.DueDate;
        }
    }
}
