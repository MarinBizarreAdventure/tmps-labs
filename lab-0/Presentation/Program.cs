using Application.Services;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using Presentation.Controllers;

class Program
{
    static void Main(string[] args)
    {
        // DIP (Dependency Inversion Principle)
        // The TaskService depends on the ITaskRepository and IRecurringTaskRepository interfaces rather than concrete
        // implementations. This allows for easy swapping of different implementations, such as mock repositories for testing.
        
        // The design ensures that high-level modules (like TaskService) are not dependent on
        // low-level modules (like TaskRepository), adhering to the principle that both should depend on abstractions.
        
        ITaskRepository taskRepository = new TaskRepository();
        IRecurringTaskRepository recurringTaskRepository = new TaskRepository(); 
        TaskService taskService = new TaskService(taskRepository, recurringTaskRepository);
        TaskController taskController = new TaskController(taskService);


         // Create tasks
        taskController.CreateTask("Learn SOLID Principles", "Study SOLID principles in C#.");
        taskController.CreateTask("Build a Console App", "Implement a task manager console application.");
        
        // Create recurring tasks
        taskController.CreateRecurringTask("Daily Standup", "Attend the daily standup meeting.", 1); 

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
        
        

        // Test GetRecurrenceFrequency and SetRecurrenceFrequency
        var recurringTask = taskService.GetTask(2) as RecurringTask; // Assuming ID 3 is the recurring task
        if (recurringTask != null)
        {   
            
            int currentFrequency = taskService.GetRecurrenceFrequency(recurringTask.Id);
            Console.WriteLine($"\nCurrent Recurrence Frequency for Task ID {recurringTask.Id}: {currentFrequency} days.");
                
            
            
            // Set a new recurrence frequency
            Console.WriteLine("\nSetting new Recurrence Frequency to 3 days...");
            bool isFrequencySet = taskService.SetRecurrenceFrequency(2, 3);
            Console.WriteLine(isFrequencySet ? "Recurrence Frequency updated successfully." : "Failed to update Recurrence Frequency.");

            // Verify the updated frequency
            int updatedFrequency = taskService.GetRecurrenceFrequency(recurringTask.Id);
            Console.WriteLine($"Updated Recurrence Frequency for Task ID {recurringTask.Id}: {updatedFrequency} days.");
        }
        else
        {
            Console.WriteLine("Recurring Task ID 3 not found.");
        }
    }

}