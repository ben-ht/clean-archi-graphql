using CoffeeShop.Core.Entities;
using CoffeeShop.Core.Interfaces;
using CoffeeShop.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace CoffeeShop.Infrastructure;
public class ProductRepository : IProductRepository
{
    private readonly CoffeeContext _context;

    public ProductRepository(CoffeeContext context)
    {
        _context = context;
    }

    public async Task<ProductDAO> Create(ProductDAO product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<ProductDAO>> GetAll()
    {
        return await _context.Products.OrderBy(p => p.ProductType).ToListAsync();
    }



}
