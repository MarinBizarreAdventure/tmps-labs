using Domain.Models.Products.Abstracions;

namespace Domain.Models.Products.Concrete;

public class Tablet : Product
{
    public string OperatingSystem { get; set; }
    public string Processor { get; set; }
    public short Ram { get; set; }
    public bool HasCellular { get; set; }     
    public bool HasStylusSupport { get; set; }
    
    
    public override IProduct Clone()
    {
        var clonedTablet = (Tablet)this.MemberwiseClone(); 
        clonedTablet.OperatingSystem = this.OperatingSystem;
        clonedTablet.Processor = this.Processor;
        clonedTablet.Ram = this.Ram;
        clonedTablet.HasCellular = this.HasCellular;
        clonedTablet.HasStylusSupport = this.HasStylusSupport;

        return clonedTablet;
    }
    
    public override void DisplayProductDetails()
    {
        base.DisplayProductDetails(); // Call base class method
        Console.WriteLine($"Operating System: {OperatingSystem}");
        Console.WriteLine($"Processor: {Processor}");
        Console.WriteLine($"RAM: {Ram} GB");
        Console.WriteLine($"Cellular Capability: {HasCellular}");
        Console.WriteLine($"Stylus Support: {HasStylusSupport}");
        Console.WriteLine("-----------------------------------");
    }
}