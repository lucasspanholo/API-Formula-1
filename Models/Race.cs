namespace API_Formula1.Models;

public class Race : BaseModel
{
    public string round { get; set; }
    public string raceName { get; set; }
    public List<Result> results { get; set; }
}