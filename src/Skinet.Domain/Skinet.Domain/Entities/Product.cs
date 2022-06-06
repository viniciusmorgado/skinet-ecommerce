using Skinet.Shared;
namespace Skinet.Domain.Entities;

#nullable disable

public class Product : BaseEntity
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }
    public ProductType ProductType { get; set; }
    public int ProductTypeId { get; init; }
    public ProductBrand ProductBrand { get; set; }
    public int ProductBrandId { get; init; }
}