using Microsoft.EntityFrameworkCore;
using Skinet.Data.Database;
using Skinet.Domain.Entities;
using Skinet.Domain.Interfaces;
namespace Skinet.Data.Repositories;

#nullable disable

public class ProductRepository : IProductRepository
{
    private readonly SkinetContext _context;

    public ProductRepository(SkinetContext context)
    {
        _context = context;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _context.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .ToListAsync();
    }
}