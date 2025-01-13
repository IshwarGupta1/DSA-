using taskmanagement.Models;
using taskmanagement;

public class StatusUpdateStrategy : IUpdateStrategy
{
    private readonly Status _newStatus;

    public StatusUpdateStrategy(Status newStatus)
    {
        _newStatus = newStatus;
    }

    public void Update(workTask task)
    {
        task.status = _newStatus;
    }
}