using Application.Services.Facade;
using Domain.Models.Products.Concrete;

class Program
{
    static void Main(string[] args)
    {
        var storeFacade = new StoreFacade();

        var laptop = new LaptopBuilder()
            .SetOperatingSystem("Windows 11")
            .SetProcessor("Intel Core i7")
            .SetRam(16)
            .SetGraphicsCard("NVIDIA GTX 3080")
            .SetIsTouchscreen(false)
            .SetId("1")
            .SetName("Gaming Laptop")
            .SetDescription("High-performance gaming laptop.")
            .SetPrice(1499.99m)
            .SetBrand("Brand A")
            .SetColor("Black")
            .SetStockQuantity(10)
            .Build();

        var smartphone = new SmartphoneBuilder()
            .SetOperatingSystem("Android 12")
            .SetProcessor("Snapdragon 888")
            .SetRam(8)
            .SetCameraResolution(108)
            .SetIs5GEnabled(true)
            .SetId("2")
            .SetName("Flagship Smartphone")
            .SetDescription("Top-of-the-line smartphone.")
            .SetPrice(999.99m)
            .SetBrand("Brand B")
            .SetColor("Silver")
            .SetStockQuantity(20)
            .Build();

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
    }
}