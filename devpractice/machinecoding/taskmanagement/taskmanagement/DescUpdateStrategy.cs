using taskmanagement.Models;
using taskmanagement;

public class DescUpdateStrategy : IUpdateStrategy
{
    private readonly string _newDesc;

    public DescUpdateStrategy(string newDesc)
    {
        _newDesc = newDesc;
    }

    public void Update(workTask task)
    {
        task.desc = _newDesc;
    }
}