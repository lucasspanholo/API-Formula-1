using API_Formula1.Models;

namespace API_Formula1.DTOs;

public class F1ApiResponseDTO
{
    public string api { get; set; }
    public int season { get; set; }
    public Race race { get; set; }
}