using Skinet.Domain.Entities;
namespace Skinet.Domain.Interfaces;

public interface IProductBrandRepository
{
    Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
}