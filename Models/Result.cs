namespace API_Formula1.Models;

public class Result : BaseModel
{
    public int position { get; set; }
    public int points { get; set; }
    public int grid { get; set; }
    public string time { get; set; }
    public Driver driver { get; set; }
}