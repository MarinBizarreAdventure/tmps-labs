# Design Patterns Implementation in C# – Report

This report showcases the implementation of several design patterns in C#, specifically focusing on **Facade**, **Decorator**, and **Composite** patterns. These patterns are designed to manage complexity and enhance maintainability in software systems, making them more modular and scalable. Below, we will describe each pattern, provide examples, and explain their use cases.

## 1. Facade Pattern

The **Facade** pattern provides a simplified interface to a complex subsystem, hiding the complexity of the subsystem from the user. This pattern makes it easier to interact with a system by offering a higher-level interface.

### Example: E-commerce Store Facade

In this example, we have a `StoreFacade` that simplifies the process of adding products, creating orders, applying warranties, and calculating prices.

```csharp
var storeFacade = new StoreFacade();

var laptop = new LaptopBuilder()

var smartphone = new SmartphoneBuilder()
   
storeFacade.AddProductToStore(laptop);
storeFacade.AddProductToStore(smartphone);

var order = storeFacade.CreateNewOrder("1", "Customer's Order");
storeFacade.AddProductToOrder(laptop);
storeFacade.AddProductToOrder(smartphone);


var laptopWithWarranty = storeFacade.AddWarrantyToProduct(laptop, 12); // 12-month warranty
var smartphoneWithFeatures = storeFacade.AddExtendedFeaturesToProduct(smartphone, "Waterproof");


storeFacade.AddProductToOrder(laptopWithWarranty);
storeFacade.AddProductToOrder(smartphoneWithFeatures);

var totalPrice = storeFacade.CalculateTotalPrice();
Console.WriteLine($"Total Order Price: {totalPrice:C}");

storeFacade.DisplayOrderDetails();
```

### Explanation
- The `StoreFacade` simplifies interactions by providing a unified interface for adding products, creating orders, adding warranties, and calculating the total price.
- Users of the facade do not need to interact with the underlying complexity of the product and order management systems.

---

## 2. Decorator Pattern

The **Decorator** pattern allows for the dynamic addition of functionality to an object without altering its structure. It is particularly useful for adding responsibilities to individual objects at runtime.

### Example: Warranty Decorator

Here, a `WarrantyDecorator` is used to add warranty information to products dynamically.

```csharp
public class WarrantyDecorator : ProductDecorator
{
    private int _warrantyPeriodInMonths;

    public WarrantyDecorator(IProduct product, int warrantyPeriodInMonths) : base(product)
    {
        _warrantyPeriodInMonths = warrantyPeriodInMonths;
    }

    public override void DisplayProductDetails()
    {
        base.DisplayProductDetails();
        Console.WriteLine($"Warranty: {_warrantyPeriodInMonths} months");
    }
}
```

### Explanation
- The `WarrantyDecorator` adds warranty details to the product by extending the functionality of the base product object.
- This allows the product object to be modified dynamically without changing its core implementation.

---

## 3. Composite Pattern

The **Composite** pattern is used to treat individual objects and compositions of objects uniformly. It is useful for representing part-whole hierarchies, such as orders consisting of multiple products.

### Example: Order with Composite

In this example, the `Order` class is an implementation of the Composite pattern, where individual products and order-related components can be added or removed from an order.

```csharp
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
        // code dysplaing xdd
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
```

### Explanation
- The `Order` class can contain individual products or other order components, and each component can be treated uniformly.
- The `Add` and `Remove` methods allow for easy management of the components within an order, and the `CalculateTotalPrice` method recursively calculates the total price of all components.

---

## Conclusion

These design patterns—**Facade**, **Decorator**, and **Composite**—are powerful tools that allow for better code organization, scalability, and maintainability. They help in handling complexity by abstracting and simplifying interactions between different parts of a system.

- **Facade** offers a simplified interface to a complex system.
- **Decorator** allows for dynamic extension of functionality.
- **Composite** treats individual objects and compositions uniformly.

By implementing these patterns in a real-world e-commerce scenario, we can create systems that are flexible, easily maintainable, and scalable.