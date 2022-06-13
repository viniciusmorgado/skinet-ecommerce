using Skinet.Domain.Entities;

namespace Skinet.Domain.Specifications;

public class ProductWithTypesAndBrandsSpecs : BaseSpecification<Product>
{
    public ProductWithTypesAndBrandsSpecs()
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }
}