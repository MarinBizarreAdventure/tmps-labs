using Domain.Models.Products.Abstracions;

namespace Domain.Models.Products.ProductDecorator;

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
