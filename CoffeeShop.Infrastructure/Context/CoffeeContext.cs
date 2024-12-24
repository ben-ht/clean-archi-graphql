using CoffeeShop.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace CoffeeShop.Infrastructure.Context;

public class CoffeeContext : DbContext
{
    public DbSet<ProductDAO> Products { get; set; }
    public DbSet<UserDAO> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CoffeeDb;Username=postgres;Password=123");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var product = modelBuilder.Entity<ProductDAO>();
        product.HasKey(p => p.Id);
        product.Property(p => p.Id).ValueGeneratedOnAdd();

        var user = modelBuilder.Entity<UserDAO>();
        user.HasKey(p => p.Id);
        user.Property(p => p.Id).ValueGeneratedOnAdd();

        base.OnModelCreating(modelBuilder);
    }
}
