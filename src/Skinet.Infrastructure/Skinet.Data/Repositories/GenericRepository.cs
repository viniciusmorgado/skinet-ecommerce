using Microsoft.EntityFrameworkCore;
using Skinet.Data.Database;
using Skinet.Domain.Entities;
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

    public async Task<T?> GetEntityWithSpec(ISpecification<T> specs)
    {
        return await ApplySpecification(specs).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T?>> ListAsync(ISpecification<T> specs)
    {
        return await ApplySpecification(specs).ToListAsync();
    }

    private IQueryable<T?> ApplySpecification(ISpecification<T> specs)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specs);
    }
}