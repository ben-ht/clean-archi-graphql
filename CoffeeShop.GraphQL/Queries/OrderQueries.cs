using CoffeeShop.Core.Entities;
using CoffeeShop.Core.Interfaces;
using CoffeeShop.GraphQL.Types;
using HotChocolate;
using HotChocolate.Types;

namespace CoffeeShop.GraphQL.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class OrderQueries
{
    [GraphQLDescription("Retrieves all orders of a customer.")]
    public async Task<IEnumerable<Order>> GetByClientId([Service] IOrderRepository orderRepository, int clientId)
    {
        IEnumerable<OrderDAO> orders = await orderRepository.GetByClientId(clientId);
        return orders.Select(o => new Order(o));
    }

    [GraphQLDescription("Retrieves an order by its id.")]
    [GraphQLName("order")]
    public async Task<Order> GetById([Service] IOrderRepository orderRepository, int orderId)
    {
        try
        {
            OrderDAO order = await orderRepository.GetById(orderId);
            return new Order(order);

        } catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return null;
        }
    }
}
