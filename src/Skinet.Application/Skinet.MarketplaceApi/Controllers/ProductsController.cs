using Microsoft.AspNetCore.Mvc;
using Skinet.Domain.Entities;
using Skinet.Domain.Interfaces;
namespace Skinet.MarketplaceApi.Controllers;

#nullable enable

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IProductTypeRepository _productTypeRepository;
    private readonly IProductBrandRepository _productBrandRepository;

    public ProductsController(IProductRepository productRepository
                            , IProductTypeRepository productTypeRepository
                            , IProductBrandRepository productBrandRepository)
    {
        _productRepository = productRepository;
        _productTypeRepository = productTypeRepository;
        _productBrandRepository = productBrandRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductsTask()
    {
        IReadOnlyList<Product>? products = await _productRepository.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductsByIdTask(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    [HttpGet]
    [Route("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypesTask()
    {
        return Ok(await _productTypeRepository.GetProductTypesAsync());
    }

    [HttpGet]
    [Route("brands")]
    public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandsTask()
    {
        return await _productBrandRepository.GetProductBrandsAsync();
    }
}