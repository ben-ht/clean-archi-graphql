using CoffeeShop.Core.Entities;

namespace CoffeeShop.Core.Interfaces;

public interface IUserRepository
{
    Task<UserDAO> GetById(int id);
    Task Create(UserDAO user);
}
