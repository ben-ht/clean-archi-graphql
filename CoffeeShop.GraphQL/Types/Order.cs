using CoffeeShop.Core.Entities;

namespace CoffeeShop.GraphQL.Types;
public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public double TotalPrice { get; set; }

    public Order(OrderDAO order)
    {
        Id = order.Id;
        UserId = order.User.Id;
        OrderDate = order.OrderDate;
        TotalPrice = order.TotalPrice;
    }
}
