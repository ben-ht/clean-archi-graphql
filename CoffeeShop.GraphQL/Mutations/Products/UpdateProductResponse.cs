using CoffeeShop.Core.Entities;
using CoffeeShop.GraphQL.Mutations.Common;
using GraphQL.Types;
using HotChocolate;

namespace CoffeeShop.GraphQL.Mutations.Products;
public class UpdateProductResponse : MutationResponse
{
    [GraphQLDescription("The up-to-date product.")]
    public Product? Product { get; set; }

    public UpdateProductResponse(int code, bool success, string message, ProductDAO? product) : base(code, success, message)
    {
        if (product != null)
        {
            Product = new Product(product);
        }
    }
}
