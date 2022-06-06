using Microsoft.EntityFrameworkCore;
using Skinet.Data.Database;
using Skinet.Domain.Entities;
using Skinet.Domain.Interfaces;
namespace Skinet.Data.Repositories;

#nullable disable

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly SkinetContext _context;

    public ProductTypeRepository(SkinetContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        return await _context.ProductTypes.ToListAsync();
    }
}