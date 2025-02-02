using System.ComponentModel.DataAnnotations;
namespace WNZland.Models.Domain;

public class Region
{
    [Key]
public Guid Id { get; set; }
[Required]
[MaxLength(10)]
public string Code { get; set; }
[Required]
[MaxLength(100)]
public string Name { get; set; }
public string? RegionImageUrl { get; set; }
}
