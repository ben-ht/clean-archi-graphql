using CoffeeShop.Core.Interfaces;
using GraphQL.Types;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class ProductQueries
{
    [GraphQLDescription("Retrieves the list of all products.")]
    public async Task<IEnumerable<Product>> GetAllProducts([Service] IProductRepository productRepository)
    {
        IEnumerable<CoffeeShop.Core.Entities.ProductDAO> products = await productRepository.GetAll();
        return products.Select(p => new Product(p));
    }
}
