using Domain.Models.Products.Abstracions;

namespace Domain.Models.Products.ProductDecorator;

public abstract class ProductDecorator : IProduct
{
    private IProduct _product;

    protected ProductDecorator(IProduct product)
    {
        _product = product;
    }

    public virtual string Id
    {
        get => _product.Id;
        set => _product.Id = value;
    }

    public virtual string Name
    {
        get => _product.Name;
        set => _product.Name = value;
    }

    public virtual string Description
    {
        get => _product.Description;
        set => _product.Description = value;
    }

    public virtual decimal Price
    {
        get => _product.Price;
        set => _product.Price = value;
    }

    public virtual string Brand
    {
        get => _product.Brand;
        set => _product.Brand = value;
    }

    public virtual string Color
    {
        get => _product.Color;
        set => _product.Color = value;
    }

    public virtual int StockQuantity
    {
        get => _product.StockQuantity;
        set => _product.StockQuantity = value;
    }

    public virtual void DisplayProductDetails()
    {
        _product.DisplayProductDetails();
    }

    public virtual decimal CalculateTotalPrice()
    {
        return _product.CalculateTotalPrice(); 
    }
    
    public virtual IProduct Clone()
    {
        return _product.Clone();
    }
}
