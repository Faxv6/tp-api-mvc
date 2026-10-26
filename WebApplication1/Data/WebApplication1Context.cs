using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;


namespace WebApplication1.Data;

public class WebApplication1Context : DbContext
{
    public DbSet<Product> Products { get; set; }

    public WebApplication1Context(DbContextOptions<WebApplication1Context> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Mouse", Price = 50 },
            new Product { Id = 2, Name = "Teclado", Price = 80 },
            new Product { Id = 3, Name = "Monitor", Price = 300 },
            new Product { Id = 4, Name = "Auriculares", Price = 45 },
            new Product { Id = 5, Name = "Webcam", Price = 70 }
        );

        base.OnModelCreating(modelBuilder);
    }
}