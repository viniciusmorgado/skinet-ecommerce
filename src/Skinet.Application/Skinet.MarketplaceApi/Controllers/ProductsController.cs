using Microsoft.AspNetCore.Mvc;
namespace Skinet.Application.MarketplaceApi;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "this will be a list of products";
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "this will be a single product!";
    }
}