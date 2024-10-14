# Laboratory 0 - Task Management System  
**Author:** Negai Marin / FAF-223  

## Objectives:
Implement the full set of SOLID principles in a task management system.

## Implementation:
The Task Management System allows users to manage tasks by utilizing various SOLID principles. 
Each component of the system is designed to fulfill a specific role.

## Key SOLID Principles

### Single Responsibility Principle (SRP):
Each class in the system has a single responsibility, which ensures that changes in one area do not affect others.\
For instance:
- **TaskService:** Manages business logic.
- **ITaskRepository:** Focuses solely on data storage and retrieval of tasks.
- **Task:** Focuses only on task functionality.
**Example: TaskService Implementation**
```csharp
public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IRecurringTaskRepository _recurringTaskRepository;

    public TaskService(ITaskRepository taskRepository, IRecurringTaskRepository recurringTaskRepository)
    {
        _taskRepository = taskRepository;
        _recurringTaskRepository = recurringTaskRepository;
    }
    
    public bool CreateTask(string title, string description)
    {
        var task = new Domain.Models.Task(title, description);
        return _taskRepository.AddTask(task);
    }

}
```

### Open/Closed Principle (OCP):
The system is designed to be open for extension but closed for modification. 
New types of tasks can be added without altering existing code. For example

**Example: OCP**
```csharp
public void DisplayAllTasks()
        {
            IEnumerable<Domain.Models.Task> tasks = _taskService.GetAllTasks();
            foreach (var task in tasks)
            { 
                // OCP (Open Closed Principle)
                // Closed for modification open for extension since new types of tasks can be added without changing
                // existing code.
                // the DisplayAllTasks can handle any type of Taks because of the polymorphic behavior  
                
                Console.WriteLine(task.GetTaskDetails());
            }
        }
```

### Liskov Substitution Principle (LSP):
The system ensures that subclasses can replace their base classes without affecting the correctness of the application.
Tasks of different types can be treated uniformly.

**Example: Task List Storage**
```csharp
private List<Domain.Models.Task> _tasks = new List<Task>();
```
In this list, various types of tasks can be stored without compromising the system's integrity.

### Interface Segregation Principle (ISP):
Interfaces are designed to be specific to their intended functions. For instance, `ITaskRepository` handles task operations while `IRecurringTaskRepository` manages recurring tasks. This keeps interfaces lean and focused.

**Example: ITaskRepository Interface**
```csharp
public interface ITaskRepository
{ 
    bool AddTask(Task task);
    bool UpdateTask(Task task);
    bool DeleteTask(int id);
    Task GetTask(int id);
    IEnumerable<Task> GetAllTasks();
}
```

### Dependency Inversion Principle (DIP):
High-level modules depend on abstractions, not concrete implementations. This design allows for easier testing and swapping of components.

**Example: TaskService Dependency Injection**
```csharp
ITaskRepository taskRepository = new TaskRepository();
IRecurringTaskRepository recurringTaskRepository = new RecurringTaskRepository();
TaskService taskService = new TaskService(taskRepository, recurringTaskRepository);
```
By depending on interfaces rather than concrete implementations, the system supports greater flexibility and easier testing.

## Conclusion

In this laboratory work I tried to show all SOLID PRinciples in a very simple project with a lack of detailed examples,
I thouth that just showing them is more important then an logical implementation of other components. Here we have all 
solid principles, we have SRP, our classes like task are focused only on task functionality. We do have Open Closed Principle,
our system is able to show different classes with a enough level of abstractisation to not change it after,
Liskov Substitution Principle, in or system all subclasses can replace their superclass without affecting the code,
Interface are focused on their main work and are segregated in smaller once, and we have implemented dependency Inversion of layers.

Examples are not written the best, its 5 in the morning xddd, but Im shure they are enough to count as implemented.
