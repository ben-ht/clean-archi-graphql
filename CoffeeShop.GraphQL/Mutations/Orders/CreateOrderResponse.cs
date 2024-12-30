using CoffeeShop.Core.Entities;
using CoffeeShop.GraphQL.Mutations.Common;
using CoffeeShop.GraphQL.Types;

namespace CoffeeShop.GraphQL.Mutations.Orders;
public class CreateOrderResponse : MutationResponse
{
    public Order? Order { get; set; }

    public CreateOrderResponse(int code, bool success, string message, OrderDAO? order) : base(code, success, message)
    {
        if (order != null)
        {
            Order = new Order(order);
        }
    }
}
