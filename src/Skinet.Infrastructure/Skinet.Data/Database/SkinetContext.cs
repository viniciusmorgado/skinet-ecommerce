using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Entities;

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

    public DbSet<Product> Products { get; set; }
}