using CoffeeShop.Core.Entities;
using GraphQL.Types;
using HotChocolate;

namespace GraphQL.Mutations.Products;
public class CreateProductResponse
{
    [GraphQLDescription("Similar to HTTP status code, represents the status of the mutation.")]
    public int Code { get; set; }

    [GraphQLDescription("Indicates whether the mutation was successful.")]
    public bool Success { get; set; }

    [GraphQLDescription("Human-readable message for the UI.")]
    public string Message { get; set; }

    [GraphQLDescription("The newly created product.")]
    public Product? Product { get; set; }

    public CreateProductResponse(int code, bool success, string message, ProductDAO? productDao)
    {
        Code = code;
        Success = success;
        Message = message;
        
        if (productDao != null)
        {
            Product = new Product(productDao);
        }
    }
}
