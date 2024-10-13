namespace Domain.Interfaces;

public interface ITaskService
{
    bool CreateTask(string title, string description);
    bool UpdateTask(int id, string title, string description);
    bool DeleteTask(int id);
    Domain.Models.Task GetTask(int id);
    IEnumerable<Domain.Models.Task> GetAllTasks();
}