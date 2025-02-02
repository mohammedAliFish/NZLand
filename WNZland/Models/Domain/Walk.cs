
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WNZland.Models.Domain;

public class Walk
{
    [Key]
public Guid Id { get; set; }
[Required]
[MaxLength(100)]
public string Name { get; set; }
[Required]
[MaxLength(1000)]
public string Description { get; set; }
[Required]
[Range(0.1 , double.MaxValue , ErrorMessage = "Length must be greater than 0")]
public double LengthInkm { get; set; }
public string? WalkImageUrl { get; set; }


[Required]
[ForeignKey(nameof(Difficulty))]
public Guid DifficultyId { get; set; }
public Difficulty Difficulty { get; set; }

[Required]
[ForeignKey(nameof(Region))]
public Guid RegionId { get; set; }

public Region Region { get; set; }
}
