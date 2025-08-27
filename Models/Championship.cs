using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Formula1.Models;

[Table("Championship")]
public class Championship : BaseModel
{
    [Required]
    public int Ano { get; set; }
    public int TotalRaces { get; set; } = 0;
    public int CompletedRaces { get; set; } = 0;
    public int RemainingRaces => TotalRaces - CompletedRaces;
}