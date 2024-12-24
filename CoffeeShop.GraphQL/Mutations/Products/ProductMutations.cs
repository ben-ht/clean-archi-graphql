using CoffeeShop.Core.Entities;
using CoffeeShop.Core.Interfaces;
using CoffeeShop.GraphQL.Mutations.Common;
using CoffeeShop.GraphQL.Mutations.Products;
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
        try
        {
            ProductDAO product = await productRepository.Create(input.ToProduct());

            return new CreateProductResponse(
                201,
                true,
                "Successfully created the product.",
                product
            );
        }
        catch (Exception ex) 
        {
            return new CreateProductResponse(
                500,
                false,
                ex.Message,
                null
            );
        }
    }

    [GraphQLDescription("Updates a product.")]
    public async Task<UpdateProductResponse> UpdateProduct(
        [Service] IProductRepository productRepository,
        UpdateProductInput input)
    {
        try
        {
            ProductDAO product = await productRepository.Update(input.ToProduct());

            return new UpdateProductResponse(
                200,
                true,
                "Successfully updated the product.",
                product
            );
        } catch (Exception ex)
        {
            return new UpdateProductResponse(
                500,
                false,
                ex.Message,
                null
            );
        }
    }

    [GraphQLDescription("Deletes a product from the products list.")]
    public async Task<MutationResponse> DeleteProduct(
        [Service] IProductRepository productRepository,
        int id)
    {
        try
        {
            await productRepository.Delete(id);

            return new MutationResponse(
                204,
                true,
                "Successfully deleted the product."
            );
        }
        catch (Exception ex)
        {
            return new MutationResponse(
                500,
                false,
                ex.Message
            );
        }
    }
}
