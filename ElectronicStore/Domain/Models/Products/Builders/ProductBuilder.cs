using Domain.Models.Products;
using Domain.Models.Products.Abstracions;
using Domain.Models.Products.Concrete;

public abstract class ProductBuilder<T> where T : Product, new()
{
    protected T product = new T();

    public ProductBuilder<T> SetId(string id)
    {
        product.Id = id;
        return this;
    }

    public ProductBuilder<T> SetName(string name)
    {
        product.Name = name;
        return this;
    }

    public ProductBuilder<T> SetDescription(string description)
    {
        product.Description = description;
        return this;
    }

    public ProductBuilder<T> SetPrice(decimal price)
    {
        product.Price = price;
        return this;
    }

    public ProductBuilder<T> SetBrand(string brand)
    {
        product.Brand = brand;
        return this;
    }

    public ProductBuilder<T> SetColor(string color)
    {
        product.Color = color;
        return this;
    }

    public ProductBuilder<T> SetStockQuantity(int stockQuantity)
    {
        product.StockQuantity = stockQuantity;
        return this;
    }

    public T Build()
    {
        return product;
    }
}


public class LaptopBuilder : ProductBuilder<Laptop>
{
    public LaptopBuilder SetOperatingSystem(string operatingSystem)
    {
        product.OperatingSystem = operatingSystem;
        return this;
    }

    public LaptopBuilder SetProcessor(string processor)
    {
        product.Processor = processor;
        return this;
    }

    public LaptopBuilder SetRam(short ram)
    {
        product.Ram = ram;
        return this;
    }

    public LaptopBuilder SetGraphicsCard(string graphicsCard)
    {
        product.GraphicsCard = graphicsCard;
        return this;
    }

    public LaptopBuilder SetIsTouchscreen(bool isTouchscreen)
    {
        product.IsTouchscreen = isTouchscreen;
        return this;
    }
}

public class SmartphoneBuilder : ProductBuilder<Smartphone>
{
    public SmartphoneBuilder SetOperatingSystem(string operatingSystem)
    {
        product.OperatingSystem = operatingSystem;
        return this;
    }

    public SmartphoneBuilder SetProcessor(string processor)
    {
        product.Processor = processor;
        return this;
    }

    public SmartphoneBuilder SetRam(short ram)
    {
        product.Ram = ram;
        return this;
    }

    public SmartphoneBuilder SetCameraResolution(int cameraResolution)
    {
        product.CameraResolution = cameraResolution;
        return this;
    }

    public SmartphoneBuilder SetIs5GEnabled(bool is5GEnabled)
    {
        product.Is5GEnabled = is5GEnabled;
        return this;
    }
}

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