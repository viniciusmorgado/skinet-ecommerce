using Skinet.Domain.Entities;
namespace Skinet.Domain.Interfaces;

public interface IProductTypeRepository
{
    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
}