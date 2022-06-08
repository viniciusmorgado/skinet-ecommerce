using Skinet.Shared;
using Skinet.Shared.BaseClasses;

namespace Skinet.Domain.Interfaces.IRepositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
}