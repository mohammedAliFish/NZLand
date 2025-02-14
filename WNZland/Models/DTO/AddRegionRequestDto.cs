
using System.ComponentModel.DataAnnotations;

namespace WNZland.Models.DTO;

public class AddRegionRequestDto
{
    [Required]
    [MinLength(3 ,ErrorMessage = "Code must be at least 3 characters long")]
    [MaxLength(3 ,ErrorMessage = "Code must be at most 3 characters long")]
public string Code { get; set; }

[Required]
[MaxLength(50 ,ErrorMessage = "Name must be a maximum of 100 characters ")]
public string Name { get; set; }
public string? RegionImageUrl { get; set; }
}
