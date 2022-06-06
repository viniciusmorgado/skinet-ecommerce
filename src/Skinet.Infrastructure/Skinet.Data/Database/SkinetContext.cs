using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Entities;
using System.Reflection;
namespace Skinet.Data.Database;

#nullable disable

public class SkinetContext : DbContext
{
    private readonly IConfiguration _configuration;

    public SkinetContext(IConfiguration configuration) => _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=Skinet; Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
}