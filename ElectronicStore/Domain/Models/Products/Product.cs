using Domain.Abstractions;
using Domain.Models.Orders.Abstractions;
using Domain.Models.Products.Abstracions;
using Microsoft.VisualBasic;

namespace Domain.Models.Products;

public class Product: IProduct, ISubject 
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    private int _stockQuantity { get; set; }
    
    public int StockQuantity
    {
        get => _stockQuantity;
        set
        {
            _stockQuantity = value;
            if (_stockQuantity > 0) NotifyObservers($"Product '{Name}' is back in stock!");
        }
    }
    
    private readonly List<IObserver> _observers = new();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
    
    public virtual IProduct Clone()
    {
        return new Product
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            Price = this.Price,
            Brand = this.Brand,
            Color = this.Color,
            StockQuantity = this.StockQuantity
        };
    }
    public virtual void DisplayProductDetails()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Price: {CalculateTotalPrice():C}");
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Stock Quantity: {StockQuantity}");
        Console.WriteLine("-----------------------------------");
    }
    
    public decimal CalculateTotalPrice()
    {
        return Price;
    }

}