using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Presentation.Controllers;

class Program
{
    static void Main(string[] args)
    {
        // Manually instantiate dependencies
        ITaskRepository taskRepository = new TaskRepository();
        ITaskService taskService = new TaskService(taskRepository);
        TaskController taskController = new TaskController(taskService);

        // Sample Interactions

        // Create tasks
        taskController.CreateTask("Learn SOLID Principles", "Study SOLID principles in C#.");
        taskController.CreateTask("Build a Console App", "Implement a task manager console application.");

        Console.WriteLine("\nAll Tasks:");
        taskController.DisplayAllTasks();

        // Update a task
        Console.WriteLine("\nUpdating Task ID 1...");
        taskController.UpdateTask(1, "Learn SOLID Principles", "Study SOLID principles in C# with examples.");

        // Display a specific task
        Console.WriteLine("\nDisplaying Task ID 1:");
        taskController.DisplayTask(1);

        // Delete a task
        Console.WriteLine("\nDeleting Task ID 2...");
        taskController.DeleteTask(2);

        // Display all tasks after deletion
        Console.WriteLine("\nAll Tasks After Deletion:");
        taskController.DisplayAllTasks();

        // Add more tasks for additional testing
        Console.WriteLine("\nAdding more tasks for additional testing");
        taskController.CreateTask("Write Unit Tests", "Implement unit tests for the application.");
        taskController.CreateTask("Learn Design Patterns", "Study common design patterns in C#.");

        // Display all tasks again
        Console.WriteLine("\nAll Tasks After Adding More Tasks:");
        taskController.DisplayAllTasks();
    }
}