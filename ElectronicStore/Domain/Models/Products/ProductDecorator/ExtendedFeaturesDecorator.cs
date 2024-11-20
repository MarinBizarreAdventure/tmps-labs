using Domain.Models.Products.Abstracions;

namespace Domain.Models.Products.ProductDecorator;

public class ExtendedFeaturesDecorator : ProductDecorator
{
    private string _additionalFeatures;

    public ExtendedFeaturesDecorator(IProduct product, string additionalFeatures) : base(product)
    {
        _additionalFeatures = additionalFeatures;
    }

    public override void DisplayProductDetails()
    {
        base.DisplayProductDetails();
        Console.WriteLine($"Additional Features: {_additionalFeatures}");
    }
}
