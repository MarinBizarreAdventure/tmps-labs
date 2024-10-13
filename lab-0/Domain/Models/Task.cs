namespace Domain.Models;

public class Task
{   
    // SRP (Single Responsibility Principle)
    // The Task class is responsible solely for task-related data and behavior
    // (e.g., properties like Title, Description, methods like MarkAsCompleted, UpdateTask).
    // It doesn't handle task storage or any other unrelated concerns.
    public int Id { get; set; }
    public string Title { get; private set;}
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Task(string title, string description)
    {
        Title = title;
        Description = description;
        IsCompleted = false;
        CreatedAt = DateTime.Now;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public void MarkAsIncomplete()
    {
        IsCompleted = false;
    }

    public void UpdateTask(string title, string description)
    {
        Title = title;
        Description = description;
    }
}