using Domain.Models.Products.Abstracions;

namespace Domain.Models.Products.Concrete;

public class Smartphone : Product
{
    public string OperatingSystem { get; set; }
    public string Processor { get; set; }
    public short Ram { get; set; }
    public int CameraResolution { get; set; }
    public bool Is5GEnabled { get; set; }

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
    
    public override void DisplayProductDetails()
    {
        base.DisplayProductDetails(); // Call base class method
        Console.WriteLine($"Operating System: {OperatingSystem}");
        Console.WriteLine($"Processor: {Processor}");
        Console.WriteLine($"RAM: {Ram} GB");
        Console.WriteLine($"Camera Resolution: {CameraResolution} MP");
        Console.WriteLine($"5G Enabled: {Is5GEnabled}");
        Console.WriteLine("-----------------------------------");
    }
}