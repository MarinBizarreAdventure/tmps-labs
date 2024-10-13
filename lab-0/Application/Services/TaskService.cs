using Domain.Interfaces;
using Domain.Models;
namespace Application.Services;

public class TaskService : ITaskService
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

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public bool CreateTask(string title, string description)
    {
        var task = new Domain.Models.Task(title, description);
        return _taskRepository.AddTask(task);
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


}