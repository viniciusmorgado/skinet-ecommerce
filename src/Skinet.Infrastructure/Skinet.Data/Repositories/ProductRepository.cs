using Skinet.Data.Database;
using Skinet.Domain.Entities;
using Skinet.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Interfaces.IRepositories;

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
        const int typeId = 1;
        
        Task<List<Product>> products = _context.Products
            .Where(x => x.ProductTypeId == typeId)
            .Include(x => x.ProductType)
            .ToListAsync();
        
        return await _context.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .ToListAsync();
    }
}