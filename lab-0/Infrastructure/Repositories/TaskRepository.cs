using Domain.Interfaces;
using Task = Domain.Models.Task;

namespace Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private List<Domain.Models.Task> _tasks = new List<Task>();

    public bool AddTask(Task task)
    {
        task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
        _tasks.Add(task);
        return true;
    }

    public bool UpdateTask(Task task)
    {
        var existingTask = GetTask(task.Id);
        if (existingTask != null)
        {
            existingTask.UpdateTask(task.Title, task.Description);
            return true;
        }

        return false;
    }
    
    public bool DeleteTask(int id)
    {
        var task = GetTask(id);
        if (task != null)
        {
            _tasks.Remove(task);
            return true;
        }

        return false;
    }

    public Task GetTask(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }
    
    public IEnumerable<Task> GetAllTasks()
    {
        return _tasks;
    }
}