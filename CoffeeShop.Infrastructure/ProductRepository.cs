﻿using CoffeeShop.Core.Entities;
using CoffeeShop.Core.Interfaces;
using CoffeeShop.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace CoffeeShop.Infrastructure;
public class ProductRepository : IProductRepository
{
    private readonly CoffeeContext _context;
    private const string IMAGE_FOLDER = "http://localhost:5118/images/";

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

    public async Task Delete(int id)
    {
        ProductDAO product = await _context.Products.FindAsync(id)
            ?? throw new ArgumentException("No product is associated to this ID.");
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductDAO>> GetAll()
    {
        var products =  _context.Products.OrderBy(p => p.ProductType);
        foreach (var product in products)
        {
            product.Image = IMAGE_FOLDER + product.Image;
        }

        return await products.ToListAsync();
    }   

    public async Task<ProductDAO> Update(ProductDAO product)
    {
        ProductDAO productDao = await _context.Products.FindAsync(product.Id)
            ?? throw new ArgumentException("No product is associated to this ID.");

        productDao.Name = product.Name;
        productDao.Description = product.Description;
        productDao.Price = product.Price;
        productDao.Image = product.Image;
        productDao.ProductType = product.ProductType;

        await _context.SaveChangesAsync();
        return productDao;
    }
}
