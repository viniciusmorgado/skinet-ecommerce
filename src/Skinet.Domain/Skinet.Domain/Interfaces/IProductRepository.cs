using Skinet.Domain.Entities;
namespace Skinet.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetProductsAsync();
}