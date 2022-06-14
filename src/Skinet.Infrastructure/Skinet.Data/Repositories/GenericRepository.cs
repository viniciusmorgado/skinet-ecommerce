using Skinet.Data.Database;
using Skinet.Domain.Interfaces.IRepositories;
using Skinet.Domain.Interfaces.ISpecifications;
using Skinet.Domain.Specifications;
using Skinet.Shared.BaseClasses;

namespace Skinet.Data.Repositories;
#nullable disable

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly SkinetContext _context;
    public GenericRepository(SkinetContext context) => _context = context;
    
    public IEnumerable<T> GetAllAsync(ISpecification<T> specs)
    {
        return SpecifierEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specs);
    }
    
    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
}