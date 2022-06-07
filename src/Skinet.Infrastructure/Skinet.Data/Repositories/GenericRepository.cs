using Microsoft.EntityFrameworkCore;
using Skinet.Data.Database;
using Skinet.Domain.Interfaces;
using Skinet.Shared;
namespace Skinet.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly SkinetContext _context;
    
    public GenericRepository(SkinetContext context)
    {
        _context = context;
    }
    
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
}