using CoffeeShop.Core.Entities;

namespace CoffeeShop.Core.Interfaces;
public interface IOrderRepository
{
    Task<OrderDAO> Create(OrderDAO orderDAO); 
    Task<IEnumerable<OrderDAO>> GetByClientId(int clientId);
    Task<OrderDAO> GetById(int orderId);
}
