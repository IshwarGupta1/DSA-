using TaskManagerServer.Entities;

namespace TaskManagerServer.Strategies
{
    public interface ITaskUpdateStrategy
    {
        void UpdateTask(TaskEntity taskEntity, TaskEntity newTaskData);
    }
}
