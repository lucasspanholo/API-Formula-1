using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Formula1.Models;

[Table("Team")]
public class Team : BaseModel
{
    [Required]
    public string TeamName { get; set; }
    public string TeamNationality { get; set; }
}