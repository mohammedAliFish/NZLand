using System.ComponentModel.DataAnnotations;

namespace WNZland.Models.Domain
{
    public class Difficulty
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}