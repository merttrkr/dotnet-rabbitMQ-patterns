using BasketService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BasketService.Infrastructure.Persistence;

public class AppDbContext:DbContext
{
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> Items { get; set; }

    public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
    {
        Database.EnsureCreated();   
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
