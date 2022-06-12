using Skinet.Domain.Interfaces.ISpecifications;
using Skinet.Shared.BaseClasses;

namespace Skinet.Domain.Interfaces.IRepositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T?> GetEntityWithSpec(ISpecification<T> specs);
    Task<IReadOnlyList<T?>> ListAsync(ISpecification<T> specs);
}