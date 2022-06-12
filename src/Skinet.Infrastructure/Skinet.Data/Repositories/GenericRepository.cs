using Microsoft.EntityFrameworkCore;
using Skinet.Data.Database;
using Skinet.Domain.Interfaces.IRepositories;
using Skinet.Domain.Interfaces.ISpecifications;
using Skinet.Shared.BaseClasses;

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

    public Task<T> GetEntityWithSpec(ISpecification<T> specs)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specs)
    {
        throw new NotImplementedException();
    }
}