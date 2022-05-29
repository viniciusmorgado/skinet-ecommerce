using System.ComponentModel.DataAnnotations;
namespace Skinet.Domain.Entities;
#nullable disable

public class Product
{
    [Key]
    public int ProductId { get; init; }
    public string ProductName { get; set; }
}