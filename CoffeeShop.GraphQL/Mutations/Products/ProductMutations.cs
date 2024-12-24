using CoffeeShop.Core.Entities;
using CoffeeShop.Core.Interfaces;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.Mutations.Products;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class ProductMutations
{
    [GraphQLDescription("Creates a product.")]
    public async Task<CreateProductResponse> CreateProduct(
        [Service] IProductRepository productRepository,
        CreateProductInput input)
    {
        ProductDAO product = await productRepository.Create(input.ToProduct());

        return new CreateProductResponse(
            200,
            true,
            "Successfully created the product.",
            product
        );
        
    }
}
