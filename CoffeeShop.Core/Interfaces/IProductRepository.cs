﻿using CoffeeShop.Core.Entities;

namespace CoffeeShop.Core.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<ProductDAO>> GetAll();

    Task<ProductDAO> Create(ProductDAO product);
}