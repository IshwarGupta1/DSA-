using TaskManagerServer.Entities;

namespace TaskManagerServer.Strategies
{
    public class UpdateTaskStatusStrategy : ITaskUpdateStrategy
    {
        public void UpdateTask(TaskEntity existingTask, TaskEntity newTask)
        {
            existingTask.TaskStatus = newTask.TaskStatus;
        }
    }
}
