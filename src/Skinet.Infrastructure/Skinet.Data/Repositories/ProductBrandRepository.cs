using Microsoft.EntityFrameworkCore;
using Skinet.Data.Database;
using Skinet.Domain.Entities;
using Skinet.Domain.Interfaces;
namespace Skinet.Data.Repositories;

#nullable disable

public class ProductBrandRepository : IProductBrandRepository
{
    private readonly SkinetContext _context;

    public ProductBrandRepository(SkinetContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
        return await _context.ProductBrands.ToListAsync();
    }
}