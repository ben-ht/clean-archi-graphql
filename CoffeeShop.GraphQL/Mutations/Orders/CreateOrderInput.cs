using CoffeeShop.Core.Entities;
using HotChocolate;

namespace CoffeeShop.GraphQL.Mutations.Orders;
public class CreateOrderInput
{
    [GraphQLDescription("The Id of the user who placed the order")]
    public int UserId { get; set; }

    [GraphQLDescription("The date and time at which the order was placed")]
    public DateTimeOffset? OrderDate { get; set; }

    [GraphQLDescription("The total cost of the order")]
    public double TotalPrice { get; set; }
}

public static class CreateOrderInputConverter
{
    public static OrderDAO ToOrder(this CreateOrderInput input)
    {
        return new OrderDAO
        {
            OrderDate = DateTime.UtcNow,
            TotalPrice = input.TotalPrice,
            User = new UserDAO()
            {
                Id = input.UserId,
            }
        };
    }
}
