using CoffeeShop.Core.Entities;
using CoffeeShop.Core.Interfaces;
using CoffeeShop.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Infrastructure;
public class OrderRepository : IOrderRepository
{
    private readonly CoffeeContext _context;

    public OrderRepository(CoffeeContext context)
    {
        _context = context;
    }

    public async Task<OrderDAO> Create(OrderDAO orderDAO)
    {
        orderDAO.User = await _context.Users.FindAsync(orderDAO.User.Id);
        await _context.Orders.AddAsync(orderDAO);
        await _context.SaveChangesAsync();
        return orderDAO;
    }

    public async Task<IEnumerable<OrderDAO>> GetByClientId(int clientId)
    {
        return await _context.Orders.Where(x => x.User.Id == clientId)
            .Include(x => x.User)
            .ToListAsync();
    }

    public async Task<OrderDAO> GetById(int orderId)
    {
        return await _context.Orders
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == orderId);
    }
}
