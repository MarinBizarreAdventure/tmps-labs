using Domain.Models.Products.Concrete;

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

    public void ManageStore()
    {
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

        // Create Smartphone
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

        // Create Tablet
        var tablet = new TabletBuilder()
            .SetOperatingSystem("iOS 15")
            .SetProcessor("Apple A14")
            .SetRam(6)
            .SetHasCellular(true)
            .SetHasStylusSupport(true)
            .SetId("3")
            .SetName("Premium Tablet")
            .SetDescription("High-resolution display tablet.")
            .SetPrice(499.99m)
            .SetBrand("Brand C")
            .SetColor("Gold")
            .SetStockQuantity(15)
            .Build();

        // Display original products
        Console.WriteLine("Original Laptop:");
        laptop.DisplayProductDetails();
        Console.WriteLine("Original Smartphone:");
        smartphone.DisplayProductDetails();
        Console.WriteLine("Original Tablet:");
        tablet.DisplayProductDetails();

        // Clone and modify properties
        var clonedLaptop = (Laptop)laptop.Clone();
        clonedLaptop.GraphicsCard = "NVIDIA RTX 4080";

        var clonedSmartphone = (Smartphone)smartphone.Clone();
        clonedSmartphone.Color = "Midnight Blue";

        var clonedTablet = (Tablet)tablet.Clone();
        clonedTablet.Processor = "Snapdragon 865";

        // Display cloned products
        Console.WriteLine("Cloned Laptop with Modified GPU:");
        clonedLaptop.DisplayProductDetails();
        Console.WriteLine("Cloned Smartphone with Modified Color:");
        clonedSmartphone.DisplayProductDetails();
        Console.WriteLine("Cloned Tablet with Modified Processor:");
        clonedTablet.DisplayProductDetails();
    }
}
