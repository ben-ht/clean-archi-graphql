using CoffeeShop.Core.Enums;
using HotChocolate;


namespace GraphQL.Mutations.Products;

public class CreateProductInput
{
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

    public CreateProductInput(string name, string description, double price, string image, ProductType productType)
    {
        Name = name;
        Description = description;
        Price = price;
        Image = image;
        ProductType = productType;
    }
}

public static class CreateProductInputConverter
{
    public static CoffeeShop.Core.Entities.ProductDAO ToProduct(this CreateProductInput input)
    {
        return new()
        {
            Name = input.Name,
            Description = input.Description,
            Price = input.Price,
            Image = input.Image,
            ProductType = input.ProductType
        };
    }
}