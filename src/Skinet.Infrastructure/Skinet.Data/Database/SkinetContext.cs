using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Skinet.Domain;
namespace Skinet.Infrastructure.Data;
#nullable disable

public class SkinetContext : DbContext
{
    private readonly IConfiguration _configuration;

    public SkinetContext(IConfiguration configuration) => _configuration = configuration;    

     protected override void OnConfiguring(DbContextOptionsBuilder options) =>    
        options.UseSqlServer(_configuration.GetConnectionString("SqlServerConnection"));    

    public SkinetContext([NotNull] DbContextOptions<SkinetContext> options) 
        : base (options) { }

    public DbSet<Product> Products { get; set; }
}