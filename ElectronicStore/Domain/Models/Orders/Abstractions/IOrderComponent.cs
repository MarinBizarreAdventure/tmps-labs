namespace Domain.Models.Orders.Abstractions;

public interface IOrderComponent
{
    string Id { get; }
    string Name { get; }
    public decimal Price { get; set; }
    decimal CalculateTotalPrice();
    
    void DisplayProductDetails();
}
