using CoffeeShop.Core.Enums;
using HotChocolate;
using HotChocolate.Types.Relay;

namespace CoffeeShop.GraphQL.Mutations.Products;
public class UpdateProductInput
{
    [GraphQLDescription("The ID for the product.")]
    [ID]
    public int Id { get; set; }

    [GraphQLDescription("The product name.")]
    public string Name { get; set; }

    [GraphQLDescription("The description of the product.")]
    public string Description { get; set; }

    [GraphQLDescription("The price of the product.")]
    public double Price { get; set; }

    [GraphQLDescription("The uri to the image of the product.")]
    public string Image { get; set; }

    [GraphQLDescription("The type of the product (0 = coffee / 1 = hot milk)")]
    public ProductType ProductType { get; set; }

    public UpdateProductInput(int id, string name, string description, double price, string image, ProductType productType)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Image = image;
        ProductType = productType;
    }
}

public static class UpdateProductInputConverter
{
    public static CoffeeShop.Core.Entities.ProductDAO ToProduct(this UpdateProductInput input)
    {
        return new()
        {
            Id = input.Id,
            Name = input.Name,
            Description = input.Description,
            Price = input.Price,
            Image = input.Image,
            ProductType = input.ProductType
        };
    }
}
