using API_Formula1.DTOs;
using API_Formula1.Models;

namespace API_Formula1.Services.Interfaces;

public interface IMyDriversService
{
    Task<IEnumerable<Driver>> GetMyDrivers();
    Task<Driver> GetDriverById(string id);
    Task<Driver?> CreateMyDriver(DriverDTO driverDto);
    Task<Driver?> UpdateMyDriver(DriverDTO driverDto, string driverId);
    Task<bool> DeleteMyDriver(string driverId);


}