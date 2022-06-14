using Skinet.Domain.Interfaces.ISpecifications;
using Skinet.Shared.BaseClasses;

namespace Skinet.Domain.Interfaces.IRepositories;
#nullable disable

public interface IGenericRepository<T> where T : BaseEntity
{
   IEnumerable<T> GetAllAsync(ISpecification<T> specs);
   Task<T> GetByIdAsync(int id);
}