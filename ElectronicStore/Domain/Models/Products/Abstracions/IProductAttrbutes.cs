namespace Domain.Models.Products.Abstracions;

public interface IProductAttributes
{
    IProductAttributes SetId(string id);
    IProductAttributes SetName(string name);
    IProductAttributes SetDescription(string description);
    IProductAttributes SetPrice(decimal price);
    IProductAttributes SetBrand(string brand);
    IProductAttributes SetColor(string color);
    IProductAttributes SetStockQuantity(int stockQuantity);
}