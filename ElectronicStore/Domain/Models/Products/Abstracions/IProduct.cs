﻿namespace Domain.Models.Products.Abstracions;

public interface IProduct
{
    string Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    decimal Price { get; set; }
    string Brand { get; set; }
    string Color { get; set; }
    int StockQuantity { get; set; }

    void DisplayProductDetails();
    IProduct Clone();
}