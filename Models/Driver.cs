using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Formula1.Models;

[Table("Driver")]
public class Driver : BaseModel
{
    [Required]
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Nationality { get; set; }
    public int Number { get; set; }
    public int Points { get; set; }
}