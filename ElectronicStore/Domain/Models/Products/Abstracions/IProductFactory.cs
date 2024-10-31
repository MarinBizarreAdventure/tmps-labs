namespace Domain.Models.Products.Abstracions;

public interface IProductFactory
{
    IProduct CreateProduct(string type);
}