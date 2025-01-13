// Priority Update Strategy
using taskmanagement.Models;
using taskmanagement;

public class PriorityUpdateStrategy : IUpdateStrategy
{
    private readonly Priority _newPriority;

    public PriorityUpdateStrategy(Priority newPriority)
    {
        _newPriority = newPriority;
    }

    public void Update(workTask task)
    {
        task.priority = _newPriority;
    }
}