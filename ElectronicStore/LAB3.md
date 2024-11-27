# Design Patterns Implementation in C# – Observer Pattern Laboratory Report

This report describes the implementation of the **Observer** pattern in C#, focusing on its structure and application. The **Observer** pattern defines a one-to-many relationship where changes in the **subject** are communicated to its **observers** automatically.

---

## 1. Observer Pattern Overview

The **Observer** pattern is ideal for scenarios requiring event-driven systems, such as notifications, UI updates, or real-time data changes. It allows observers to subscribe to or unsubscribe from a subject dynamically.

---

## 2. Observer Pattern Implementation Example

### Scenario: Inventory Notification System

#### Essential Components:
1. **Subject**: Maintains a list of observers and notifies them of changes.
2. **Observer**: Reacts to notifications from the subject.

#### Code:

**Subject Interface**  
```csharp
public interface ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers(string message);
}
```

**Concrete Subject**  
```csharp
public class Product: IProduct, ISubject 
{
    public string Id { get; set; }
    // acolo e mai mult code nesemnificativ pentru acest patern
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
    
}
```

**Observer Interface**  
```csharp
public interface IObserver
{
    void Update(string message);
}
```

**Concrete Observer**  
```csharp
public class Customer : IObserver
{
    public string Name { get; set; }
    // some code
    public void Update(string message)
    {
        Console.WriteLine($"Notification for {Name}: {message}");
    }
}
```

---

### Example Usage:
```csharp
public void AddProductToStore(IProduct product)
    {
        if (product is Product productWithObservers)
        {
            foreach (var customer in _customers)
            {
                productWithObservers.AddObserver(customer); 
            }
        }

        _availableProducts.Add(product);
        Console.WriteLine($"Added {product.Name} to the store.");
    }
var storeFacade = new StoreFacade();
        
var customer1 = new Customer("Alice");
        
storeFacade.RegisterCustomer(customer1);
// Simulate stock change to notify observers
laptop.StockQuantity = 5; 
```

**Output:**
```
Registered customer: Alice
Registered customer: Bob
Added Gaming Laptop to the store.
Added Flagship Smartphone to the store.
Notification for Alice: Product 'Gaming Laptop' is back in stock!
Notification for Bob: Product 'Gaming Laptop' is back in stock!
Notification for Alice: Product 'Flagship Smartphone' is back in stock!
Notification for Bob: Product 'Flagship Smartphone' is back in stock!

```

---

## 3. Key Takeaways

- **Subject** (`Product`): Tracks observers and notifies them of state changes.
- **Observer** (`Costumer`): Implements `Update` to handle notifications dynamically.
- **Notification Process**: Changes in the subject trigger a cascade of updates to its observers.

---

## 4. Conclusion

The **Observer** pattern decouples the subject from its observers, enabling scalable and dynamic systems. It is particularly useful in real-world applications like event-driven systems, news feeds, or stock price updates. The pattern simplifies communication while maintaining flexibility, making it a critical tool in software design.