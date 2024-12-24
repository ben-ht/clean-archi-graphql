using CoffeeShop.Core.Enums;
using HotChocolate;
using HotChocolate.Types.Relay;

namespace GraphQL.Types;

[GraphQLDescription("A product is a drink, either coffee or hot milk")]
public class Product
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

    
    public Product(string name, string description, string image)
    {
        Name = name;
        Description = description;
        Image = image;
    }

    public Product(CoffeeShop.Core.Entities.ProductDAO product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
        Image = product.Image;
        ProductType = product.ProductType;
    }
}
