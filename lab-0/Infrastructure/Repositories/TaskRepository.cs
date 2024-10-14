using Domain.Interfaces;
using Domain.Models;
using Task = Domain.Models.Task;

namespace Infrastructure.Repositories;

public class TaskRepository : ITaskRepository, IRecurringTaskRepository
{
    
    // LSP (Liskov Substitution Principle)
    // This list can store tasks of different types derived from the Task base class.
    // For example, RecurringTask can be substituted for Task in any instance where a Task is expected.
    // This allows system to operate correctly as long as all subclasses follow the contract of the base class
    
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
        // Find the task to delete
        var taskToDelete = GetTask(id);
        if (taskToDelete != null)
        {
            _tasks.Remove(taskToDelete);
            for (int i = 0; i < _tasks.Count; i++)
            {
                _tasks[i].Id = i + 1; 
            }

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
    
    public int GetRecurrenceFrequency(RecurringTask recurringTask)
    {
        return recurringTask.FrequencyInDays;
    }

    public bool SetRecurrenceFrequency(int recurringTaskID, int frequencyInDays)
    {
        
        RecurringTask task = _tasks.FirstOrDefault(t => t.Id == 0) as RecurringTask;
        if (task == null) return false;
        task.SetFrequency(frequencyInDays);
        return true; 
    }

}