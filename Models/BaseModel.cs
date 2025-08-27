using System.ComponentModel.DataAnnotations;

namespace API_Formula1.Models;

public class BaseModel
{
    [Key]
    [Required]
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}