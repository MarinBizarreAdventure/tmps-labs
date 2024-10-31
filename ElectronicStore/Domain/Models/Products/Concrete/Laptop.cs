using Domain.Models.Products.Abstracions;

namespace Domain.Models.Products.Concrete;

public class Laptop : Product
{
    public string OperatingSystem { get; set; }
    public string Processor { get; set; }
    public short Ram { get; set; }
    public string GraphicsCard { get; set; }
    public bool IsTouchscreen { get; set; }

    public override IProduct Clone()
    {
        var clonedLaptop = (Laptop)this.MemberwiseClone(); 
        clonedLaptop.OperatingSystem = string.Copy(this.OperatingSystem);
        clonedLaptop.Processor = string.Copy(this.Processor);
        clonedLaptop.Ram = this.Ram;
        clonedLaptop.GraphicsCard = string.Copy(this.GraphicsCard);
        clonedLaptop.IsTouchscreen = this.IsTouchscreen;

        return clonedLaptop;
    }
    
    public override void DisplayProductDetails()
    {
        base.DisplayProductDetails(); // Call base class method
        Console.WriteLine($"Operating System: {OperatingSystem}");
        Console.WriteLine($"Processor: {Processor}");
        Console.WriteLine($"RAM: {Ram} GB");
        Console.WriteLine($"Graphics Card: {GraphicsCard}");
        Console.WriteLine($"Touchscreen: {IsTouchscreen}");
        Console.WriteLine("-----------------------------------");
    }
}