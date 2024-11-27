namespace Domain.Abstractions;

public interface IObserver
{
    void Update(string message);
}