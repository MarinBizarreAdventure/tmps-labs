# Design Patterns in C#

This repository showcases three fundamental creational design patterns: **Singleton**, **Prototype**, and **Builder**. These patterns help manage object creation in a way that is flexible and efficient. Below are explanations and examples for each pattern, along with links to the relevant code.

## 1. Singleton Pattern

The Singleton pattern ensures that a class has only one instance and provides a global point of access to it. This is particularly useful for managing shared resources, such as configurations or connection pools.

### Example: Electric Store Manager

Here's a simple implementation of a Singleton for managing an electric store, I added it just as an example of implementation in future i will change this and will manege other things:

```csharp
public class ElectricStoreManager
{
    private static ElectricStoreManager _instance;

    private ElectricStoreManager() { }

    public static ElectricStoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ElectricStoreManager();
            }
            return _instance;
        }
    }
}
```

### Usage
To access the instance, simply call:

```csharp
ElectricStoreManager storeManager = ElectricStoreManager.Instance;
```

For the full code, check out [Singleton Code](\Domain\Models\ElectricStoreManager.cs).

---

## 2. Prototype Pattern

The Prototype pattern allows you to create new objects by copying an existing object, known as a prototype. This is particularly useful when the cost of creating a new instance of an object is high.

### Example: Cloning Products

Here’s how you might implement the Prototype pattern in a product class, here i implemented prototype so, for example when i have to add the same smartphone but with different collor i will just change the collor of the object:

```csharp
public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }

    public override IProduct Clone()
    {
        var clonedSmartphone = (Smartphone)this.MemberwiseClone(); 
        clonedSmartphone.OperatingSystem = string.Copy(this.OperatingSystem);
        clonedSmartphone.Processor = string.Copy(this.Processor);
        clonedSmartphone.Ram = this.Ram;
        clonedSmartphone.CameraResolution = this.CameraResolution;
        clonedSmartphone.Is5GEnabled = this.Is5GEnabled;
        return clonedSmartphone;
    }
}
```

### Usage
You can create a clone of a product as follows:

```csharp
var clonedSmartphone = (Smartphone)smartphone.Clone();
        clonedSmartphone.Color = "Midnight Blue";
```

For the complete example, please visit [Prototype Code](\Domain\Models\Products\Concrete\Smartphone.cs
).

---

## 3. Builder Pattern

The Builder pattern provides a way to construct a complex object step by step. It abstracts the construction process and allows you to create different representations of the same type.

### Example: Tablet Builder

Here’s a simple implementation of a Builder for a tablet, I implemented builder so it will be easy to manage bulding products , they have a base builder for product and after that they have their own builder that will eventually  return the object, i implmented it cause in only stores even the same products not always have all the things and so on and so for:

```csharp
public class TabletBuilder : ProductBuilder<Tablet>
{
    public TabletBuilder SetOperatingSystem(string operatingSystem)
    {
        product.OperatingSystem = operatingSystem;
        return this;
    }

    public TabletBuilder SetProcessor(string processor)
    {
        product.Processor = processor;
        return this;
    }

    public TabletBuilder SetRam(short ram)
    {
        product.Ram = ram;
        return this;
    }

    public TabletBuilder SetHasCellular(bool hasCellular)
    {
        product.HasCellular = hasCellular;
        return this;
    }

    public TabletBuilder SetHasStylusSupport(bool hasStylusSupport)
    {
        product.HasStylusSupport = hasStylusSupport;
        return this;
    }
}
```

### Usage
To create a tablet using the builder:

```csharp
Tablet tablet = new TabletBuilder()
    .SetOperatingSystem("iOS 15")
    .SetProcessor("Apple A14")
    .SetRam(6)
    .SetHasCellular(true)
    .SetHasStylusSupport(true)
    .Build();
```

For the complete code, please check [Builder Code](\Domain\Models\Products\Builders\ProductBuilder.cs).

---

## Conclusion

These design patterns are essential tools for building flexible and maintainable software. They each solve specific problems related to object creation, and by understanding them, you can improve your coding practices significantly, even if here maybe singleton is not really usefull this serves as an example, and it could be improved drastically, we can add abstract factory to it for example creating factories for different brands or categories.

Feel free to explore the code links above to see these patterns in action!

