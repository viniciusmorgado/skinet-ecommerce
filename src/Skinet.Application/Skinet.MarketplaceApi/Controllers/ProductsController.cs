using Microsoft.AspNetCore.Mvc;
using Skinet.Domain.Entities;
using Skinet.Domain.Interfaces;

namespace Skinet.MarketplaceApi.Controllers;
#nullable disable

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductsByIdTask()
    {
        var products = await _productRepository.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductsTask(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }
}