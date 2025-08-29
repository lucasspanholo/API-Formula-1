using System.Text.Json;
using API_Formula1.Data;
using API_Formula1.DTOs;
using API_Formula1.Models;
using API_Formula1.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Formula1.Services;

public class F1Service : IF1Service
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public F1Service(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //Third-Party API Integration
    public async Task<DriverDTO.DriversResponseDto> GetDriversByYearAsync(int seasonYear)
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://f1api.dev/api/{seasonYear}/drivers");
            var response = await client.SendAsync(request);

            var jsonContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            var apiResponse = JsonSerializer.Deserialize<DriverDTO.F1DriversApiResponse>(jsonContent, options);
            
            if (apiResponse?.Drivers == null)
            {
                return new DriverDTO.DriversResponseDto
                {
                    Season = seasonYear,
                    TotalDrivers = 0,
                    Drivers = new List<DriverDTO>(),
                    RetrievedAt = DateTime.UtcNow
                };
            }

            foreach (var apiDriver in apiResponse.Drivers)
            {
                var existingDriver = await _context.Drivers
                    .FirstOrDefaultAsync(d => d.Id == apiDriver.Id);

                var driver = new Driver();
                if (existingDriver == null)
                {
                    driver = _mapper.Map<Driver>(apiDriver);
                    driver.Initialize();
                    
                    await _context.Drivers.AddAsync(driver);
                    await _context.SaveChangesAsync();
                }
            }
            
            var driversResponse = new DriverDTO.DriversResponseDto
            {
                Season = seasonYear,
                TotalDrivers = apiResponse.Drivers.Count,
                Drivers = apiResponse.Drivers,
                RetrievedAt = DateTime.UtcNow
            };
            return driversResponse;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetDriversByYearAsync: {ex.Message}");
            throw;
        }
    }

    public async Task<Dictionary<string,int>> GetStandingsByRound(int year, int round)
    {
        var client = new HttpClient();
        var allRaces = new List<F1ApiResponseDTO>();

        for (int race = 1; race <= round; race++)
        {
            if (race > 1)
            {
                await Task.Delay(1000);
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://f1api.dev/api/{year}/{race}/race");
            var response = await client.SendAsync(request);

            var jsonContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            var apiReturn = JsonSerializer.Deserialize<F1ApiResponseDTO>(jsonContent, options);
            
            allRaces.Add(apiReturn);
        }
        
        var standings = allRaces
            .SelectMany(r => r.race.results)
            .Where(result => result != null && result.driver != null && !string.IsNullOrEmpty(result.driver.Id))
            .GroupBy(result => result.driver.Id)
            .ToDictionary(
                group => group.Key,
                group => group.Sum(p => p.points)
            );
        
        return standings;
    }

}