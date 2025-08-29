using API_Formula1.Models;
using API_Formula1.DTOs;

namespace API_Formula1.Services.Interfaces;

public interface IF1Service
{
    Task<DriverDTO.DriversResponseDto> GetDriversByYearAsync(int seasonYear);
    Task<Dictionary<string, int>> GetStandingsByRound(int year, int round);

}