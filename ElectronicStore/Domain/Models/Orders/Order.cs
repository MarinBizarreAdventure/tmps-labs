using Domain.Models.Orders.Abstractions;

namespace Domain.Models.Orders;

using System;
using System.Collections.Generic;

public class Order : IOrderComponent
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    private List<IOrderComponent> _orderComponents = new List<IOrderComponent>();

    public void Add(IOrderComponent component)
    {
        _orderComponents.Add(component);
    }

    public void Remove(IOrderComponent component)
    {
        _orderComponents.Remove(component);
    }

    public void DisplayProductDetails()
    {
        Console.WriteLine($"Order ID: {Id}");
        Console.WriteLine($"Order Name: {Name}");
        Console.WriteLine($"Order Price: {CalculateTotalPrice:C}");
        Console.WriteLine("Order contains:");
        foreach (var component in _orderComponents)
        {
            component.DisplayProductDetails(); 
        }
    }
    
    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = Price;
        foreach (var component in _orderComponents)
        {
            totalPrice += component.CalculateTotalPrice(); 
        }
        return totalPrice;
    }
}
