using Microsoft.AspNetCore.Mvc;
using Skinet.Domain.Entities;
using Skinet.Domain.Interfaces;
namespace Skinet.MarketplaceApi.Controllers;
#nullable disable

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IGenericRepository<ProductType> _productTypeRepository;
    private readonly IGenericRepository<ProductBrand> _productBrandRepository;

    public ProductsController(IGenericRepository<Product> productRepository
                            , IGenericRepository<ProductType> productTypeRepository
                            , IGenericRepository<ProductBrand> productBrandRepository)
    {
        _productRepository = productRepository;
        _productTypeRepository = productTypeRepository;
        _productBrandRepository = productBrandRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductsTask()
    {
        IReadOnlyList<Product> products = await _productRepository.ListAllAsync();
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
        return Ok(await _productTypeRepository.ListAllAsync());
    }

    [HttpGet]
    [Route("brands")]
    public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandsTask()
    {
        return await _productBrandRepository.ListAllAsync();
    }
}