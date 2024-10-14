using Domain.Interfaces;
using Domain.Models;
namespace Application.Services;

public class TaskService : ITaskService, IRecurringTaskService
{
    // SRP (Single Responsibility Principle)
    // The TaskService handles business logic related to tasks (creating, updating, deleting),
    // while the TaskRepository handles data storage.
    // This separation ensures that if the way you handle tasks changes, you only need to modify the TaskService
    
    // DIP (Dependency Inversion Principle)
    // High-level modules should not depend on low-level modules; both should depend on abstractions.
    // Abstractions should not depend on details; details should depend on abstractions.
    // The TaskService class depends on the ITaskRepository interface rather than a concrete implementation (TaskRepository).
    // This allows for easy swapping of implementations (e.g., using a mock repository for testing).
    
    private readonly ITaskRepository _taskRepository;
    private readonly IRecurringTaskRepository _recurringTaskRepository;


    public TaskService(ITaskRepository taskRepository, IRecurringTaskRepository  recurringTaskRepository)
    {
        _taskRepository = taskRepository;
        _recurringTaskRepository = recurringTaskRepository;
    }

    public bool CreateTask(string title, string description)
    {
        var task = new Domain.Models.Task(title, description);
        return _taskRepository.AddTask(task);
    }
    
    public bool CreateRecurringTask(string title, string description, int frequencyInDays)
    {
        var recurringTask = new RecurringTask(title, description, frequencyInDays);
        return _taskRepository.AddTask(recurringTask);
    }

    public bool UpdateTask(int id, string title, string description)
    {
        var task = _taskRepository.GetTask(id);
        if (task != null)
        {
            task.UpdateTask(title, description);
            return _taskRepository.UpdateTask(task);
        }

        return false;
    }

    public bool DeleteTask(int id)
    {
        return _taskRepository.DeleteTask(id);
    }

    public Domain.Models.Task GetTask(int id)
    {
        return _taskRepository.GetTask(id);
    }

    public IEnumerable<Domain.Models.Task> GetAllTasks()
    {
        return _taskRepository.GetAllTasks();
    }
    
    public int GetRecurrenceFrequency(RecurringTask recurringTask)
    {
        return _recurringTaskRepository.GetRecurrenceFrequency(recurringTask);
    }

    
    
    public int GetRecurrenceFrequency(int taskId)
    {
        var recurringTask = _taskRepository.GetTask(taskId) as RecurringTask;
        if (recurringTask == null) throw new Exception("Task is not a recurring task.");
        return _recurringTaskRepository.GetRecurrenceFrequency(recurringTask);
    }

    public bool SetRecurrenceFrequency(int taskId, int frequencyInDays)
    {
        var recurringTask = _taskRepository.GetTask(taskId) as RecurringTask;
        if (recurringTask == null) throw new Exception("Task is not a recurring task.");
        recurringTask.SetFrequency(frequencyInDays);
        return true;
    }

}