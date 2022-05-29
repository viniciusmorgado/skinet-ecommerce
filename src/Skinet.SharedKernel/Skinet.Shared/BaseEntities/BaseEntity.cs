using System.ComponentModel.DataAnnotations;

namespace Skinet.Shared;
#nullable disable

public class BaseEntity
{
    [Key]
    public int Id { get; init; }
}