using Domain.Interfaces;

namespace Presentation.Controllers;

public class TaskController
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public void CreateTask(string title, string description)
    {
        bool success = _taskService.CreateTask(title, description);
        Console.WriteLine(success ? "Task created successfully." : "Failed to create task.");
    }

    public void UpdateTask(int id, string title, string description)
    {
        bool success = _taskService.UpdateTask(id, title, description);
        Console.WriteLine(success ? "Task updated successfully." : "Failed to update task.");
    }

    public void DeleteTask(int id)
    {
        bool success = _taskService.DeleteTask(id);
        Console.WriteLine(success ? "Task deleted successfully." : "Failed to delete task.");
    }

    public void DisplayTask(int id)
    {
        var task = _taskService.GetTask(id);
        if (task != null)
        {
            Console.WriteLine($"Task ID: {task.Id}, Title: {task.Title}, Description: {task.Description}, Completed: {task.IsCompleted}");
            return;
        }
        Console.WriteLine("Task not found.");
    }
    
    public void DisplayAllTasks()
    {
        IEnumerable<Domain.Models.Task> tasks = _taskService.GetAllTasks();
        foreach (var task in tasks)
        {
            Console.WriteLine($"Task ID: {task.Id}, Title: {task.Title}, Description: {task.Description}, Completed: {task.IsCompleted}");
        }
    }
}