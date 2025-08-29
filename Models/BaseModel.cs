using System.ComponentModel.DataAnnotations;

namespace API_Formula1.Models;

public class BaseModel
{
    [Key]
    [Required]
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public void Initialize()
    {
        var now = DateTime.UtcNow;
        CreatedAt = now;
        UpdatedAt = now;
        Id = Guid.NewGuid().ToString();
    }
}