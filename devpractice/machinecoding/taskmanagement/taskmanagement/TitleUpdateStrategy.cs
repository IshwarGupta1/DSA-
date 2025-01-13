using taskmanagement.Models;
using taskmanagement;

public class TitleUpdateStrategy : IUpdateStrategy
{
    private readonly string _newTitle;

    public TitleUpdateStrategy(string newTitle)
    {
        _newTitle = newTitle;
    }

    public void Update(workTask task)
    {
        task.title = _newTitle;
    }
}