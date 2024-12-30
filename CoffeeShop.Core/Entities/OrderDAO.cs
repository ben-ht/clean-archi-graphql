namespace CoffeeShop.Core.Entities;

public class OrderDAO
{
    public int Id { get; set; }
    public UserDAO User { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public double TotalPrice { get; set; }

}
