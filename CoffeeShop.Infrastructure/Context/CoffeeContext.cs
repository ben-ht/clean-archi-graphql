using CoffeeShop.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace CoffeeShop.Infrastructure.Context;

public class CoffeeContext : DbContext
{
    public DbSet<ProductDAO> Products { get; set; }
    public DbSet<UserDAO> Users { get; set; }
    public DbSet<OrderDAO> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CoffeeDb;Username=postgres;Password=123");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var product = modelBuilder.Entity<ProductDAO>();
        product.HasKey(p => p.Id);

        var user = modelBuilder.Entity<UserDAO>();
        user.HasKey(u => u.Id);

        var order = modelBuilder.Entity<OrderDAO>();
        order.HasKey(o => o.Id);

        base.OnModelCreating(modelBuilder);
    }
}
