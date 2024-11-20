using Domain.Models.Orders;
using Domain.Models.Products;

namespace Application.Services.Facade;

using Domain.Models.Products.Abstracions;
using Domain.Models.Products.ProductDecorator;
using System;
using System.Collections.Generic;

public class StoreFacade
{
    private List<IProduct> _availableProducts = new List<IProduct>();
    private Order _currentOrder;

    public StoreFacade()
    {
        _currentOrder = new Order();
    }

    public void AddProductToStore(IProduct product)
    {
        _availableProducts.Add(product);
        Console.WriteLine($"Added {product.Name} to the store.");
    }

    public void RemoveProductFromStore(IProduct product)
    {
        _availableProducts.Remove(product);
        Console.WriteLine($"Removed {product.Name} from the store.");
    }

    public List<IProduct> GetAvailableProducts()
    {
        return _availableProducts;
    }

    public Order CreateNewOrder(string orderId, string orderName)
    {
        _currentOrder = new Order
        {
            Id = orderId,
            Name = orderName
        };
        Console.WriteLine($"Created new order: {orderName}");
        return _currentOrder;
    }

    public void AddProductToOrder(IProduct product)
    {
        _currentOrder.Add(product);
        Console.WriteLine($"Added {product.Name} to the order.");
    }

    public void RemoveProductFromOrder(Product product)
    {
        _currentOrder.Remove(product);
        Console.WriteLine($"Removed {product.Name} from the order.");
    }

    public IProduct AddWarrantyToProduct(IProduct product, int warrantyPeriodInMonths)
    {
        var decoratedProduct = new WarrantyDecorator(product, warrantyPeriodInMonths);
        Console.WriteLine($"Added {warrantyPeriodInMonths}-month warranty to {product.Name}");
        return decoratedProduct;
    }

    public IProduct AddExtendedFeaturesToProduct(IProduct product, string additionalFeatures)
    {
        var decoratedProduct = new ExtendedFeaturesDecorator(product, additionalFeatures);
        Console.WriteLine($"Added extended features to {product.Name}: {additionalFeatures}");
        return decoratedProduct;
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = _currentOrder.CalculateTotalPrice();
        return totalPrice;
    }

    public void DisplayOrderDetails()
    {
        _currentOrder.DisplayProductDetails();
    }
}
