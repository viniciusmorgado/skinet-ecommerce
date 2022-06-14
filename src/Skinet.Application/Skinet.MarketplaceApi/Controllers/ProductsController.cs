using Microsoft.AspNetCore.Mvc;
using Skinet.Data.Repositories;
using Skinet.Domain.Entities;
using Skinet.Domain.Interfaces;
using Skinet.Domain.Interfaces.IRepositories;
using Skinet.Domain.Specifications;

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
    public async Task<IActionResult> GetProductsTask()
    {
        ProductWithTypesAndBrandsSpecs specs = new();
        IEnumerable<Product> products = _productRepository.GetAllAsync(specs);
        return await Task.Run(() => Ok(products));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductsByIdTask(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    // [HttpGet]
    // [Route("types")]
    // public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypesTask()
    // {
    //     return Ok(await _productTypeRepository.GetProductTypesAsync());
    // }
    //
    // [HttpGet]
    // [Route("brands")]
    // public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandsTask()
    // {
    //     return await _productBrandRepository.GetProductBrandsAsync();
    // }
}