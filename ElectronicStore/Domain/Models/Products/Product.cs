using Domain.Models.Orders.Abstractions;
using Domain.Models.Products.Abstracions;
using Microsoft.VisualBasic;

namespace Domain.Models.Products;

public class Product: IProduct, IOrderComponent 
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public int StockQuantity { get; set; }

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