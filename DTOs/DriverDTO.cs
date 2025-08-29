using System.Text.Json.Serialization;

namespace API_Formula1.DTOs;

public class DriverDTO : BaseDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Nationality { get; set; }
    public int Number { get; set; }
    public int Points { get; set; }
    
    public class F1DriversApiResponse
    {
        [JsonPropertyName("drivers")]
        public List<DriverDTO> Drivers { get; set; } = new List<DriverDTO>();
    }

    public class DriversResponseDto
    {
        public int Season { get; set; }
        public int TotalDrivers { get; set; }
        public List<DriverDTO> Drivers { get; set; } = new List<DriverDTO>();
        public DateTime RetrievedAt { get; set; }
    }
}