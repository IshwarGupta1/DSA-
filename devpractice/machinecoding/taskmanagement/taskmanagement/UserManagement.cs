using taskmanagement.Models;
using taskmanagement;

public class UserManagement
{
    private readonly taskManagement _taskManagement;
    private readonly User user;

    public UserManagement(taskManagement taskManagement, User user)
    {
        _taskManagement = taskManagement ?? throw new ArgumentNullException(nameof(taskManagement));
        this.user = user ?? throw new ArgumentNullException(nameof(user));
    }

    public void createTask(string taskName, string taskDesc, int deadline, Priority priority)
    {
        var task = _taskManagement.createTask(taskName, taskDesc, deadline, priority);
        user.tasks.Add(task);
    }

    public bool updateTaskTitle(int taskid, string title)
    {
        var task = user.tasks.FirstOrDefault(t => t.id == taskid)
                   ?? throw new KeyNotFoundException($"Task with ID {taskid} not found.");

        _taskManagement.UpdateTask(task, new TitleUpdateStrategy(title));
        return true;
    }

    public bool updateTaskDesc(int taskid, string desc)
    {
        var task = user.tasks.FirstOrDefault(t => t.id == taskid)
                   ?? throw new KeyNotFoundException($"Task with ID {taskid} not found.");

        _taskManagement.UpdateTask(task, new DescUpdateStrategy(desc));
        return true;
    }

    public bool updateTaskPriority(int taskid, Priority priority)
    {
        var task = user.tasks.FirstOrDefault(t => t.id == taskid)
                   ?? throw new KeyNotFoundException($"Task with ID {taskid} not found.");

        _taskManagement.UpdateTask(task, new PriorityUpdateStrategy(priority));
        return true;
    }

    public bool updateTaskStatus(int taskid, Status status)
    {
        var task = user.tasks.FirstOrDefault(t => t.id == taskid)
                   ?? throw new KeyNotFoundException($"Task with ID {taskid} not found.");

        _taskManagement.UpdateTask(task, new StatusUpdateStrategy(status));
        return true;
    }

    public bool deleteTask(int taskid)
    {
        var task = user.tasks.FirstOrDefault(x => x.id == taskid);
        if (task == null) return false;

        user.tasks.Remove(task);
        return true;
    }

    public void assignTask(User newUser, workTask task)
    {
        if (newUser.tasks.Contains(task))
        {
            throw new InvalidOperationException("Task is already assigned to the user.");
        }

        newUser.tasks.Add(task);
    }
}
