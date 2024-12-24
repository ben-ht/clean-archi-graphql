using CoffeeShop.Core.Enums;


namespace CoffeeShop.Core.Entities;
public class ProductDAO
{
    public int Id { get; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public ProductType ProductType { get; set; }
}
