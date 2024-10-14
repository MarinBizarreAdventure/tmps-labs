using Task = Domain.Models.Task;

namespace Domain.Interfaces;

public interface ITaskRepository
{ 
    // ISP (Inteface Segregation Principle)
    // ITaskRepository interface is specific to task operations, avoiding a bloated interface
    // In need to add behaviour I will create another Interfaces  
    
    bool AddTask(Task task);
    bool UpdateTask(Task task);
    bool DeleteTask(int id);
    Task GetTask(int id);
    IEnumerable<Task> GetAllTasks();

}