using CoffeeShop.Core.Entities;
using CoffeeShop.Core.Interfaces;
using CoffeeShop.Infrastructure.Context;

namespace CoffeeShop.Infrastructure;
public class UserRepository : IUserRepository
{
    private readonly CoffeeContext _context;

    public UserRepository(CoffeeContext coffeeContext)
    {
        _context = coffeeContext;
    }

    public async Task Create(UserDAO user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<UserDAO> GetById(int id)
    {
        return await _context.Users.FindAsync(id)
            ?? throw new ArgumentException("No user found with the given ID.");
    }
}
