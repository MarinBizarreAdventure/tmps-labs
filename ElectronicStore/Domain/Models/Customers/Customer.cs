using Domain.Abstractions;

namespace Domain.Models.Customers;

public class Customer : IObserver
{
    public string Name { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"Notification for {Name}: {message}");
    }
}