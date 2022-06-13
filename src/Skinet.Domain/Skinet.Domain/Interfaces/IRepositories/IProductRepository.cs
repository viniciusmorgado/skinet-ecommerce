using Skinet.Domain.Entities;

namespace Skinet.Domain.Interfaces.IRepositories;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetProductsAsync();
}