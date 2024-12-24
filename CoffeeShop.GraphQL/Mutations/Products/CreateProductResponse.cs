using CoffeeShop.Core.Entities;
using CoffeeShop.GraphQL.Mutations.Common;
using GraphQL.Types;
using HotChocolate;

namespace GraphQL.Mutations.Products;
public class CreateProductResponse : MutationResponse
{
    [GraphQLDescription("The newly created product.")]
    public Product? Product { get; set; }

    public CreateProductResponse(int code, bool success, string message, ProductDAO? productDao) : base(code, success, message)
    {    
        if (productDao != null)
        {
            Product = new Product(productDao);
        }
    }
}
