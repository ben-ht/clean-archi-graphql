using CoffeeShop.Core.Entities;
using CoffeeShop.Core.Interfaces;
using HotChocolate;
using HotChocolate.Types;

namespace CoffeeShop.GraphQL.Mutations.Orders;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class OrderMutations
{
    [GraphQLDescription("Creates an order.")]
    public async Task<CreateOrderResponse> CreateOrder(
        [Service] IOrderRepository orderRepository,
        CreateOrderInput input)
    {
        try
        {
            OrderDAO order = await orderRepository.Create(input.ToOrder());

            return new CreateOrderResponse(
                201,
                true,
                "Successfully placed the order",
                order);
        }
        catch (Exception ex)
        {
            return new CreateOrderResponse(
                500,
                false,
                ex.Message,
                null);
        }
    }
}
