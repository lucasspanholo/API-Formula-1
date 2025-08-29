using API_Formula1.Data;
using API_Formula1.DTOs;
using API_Formula1.Models;
using API_Formula1.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Formula1.Services;

public class MyDriversService : IMyDriversService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public MyDriversService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Driver>> GetMyDrivers()
    {
        var drivers = _context.Drivers.ToListAsync();
        
        return await drivers;
    }

    public async Task<Driver> GetDriverById(string id)
    {
        var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Id == id);
        return driver;
    }
    
    public async Task<Driver?> CreateMyDriver(DriverDTO driverDto)
    {
        var driver = _mapper.Map<Driver>(driverDto);
        driver.Initialize();
        await _context.Drivers.AddAsync(driver);
        await _context.SaveChangesAsync();
        return driver;
    }

    public async Task<Driver?> UpdateMyDriver(DriverDTO driverDto, string driverId)
    {
        try
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Id == driverId);

            if (driver == null)
            {
                return null;
            }
            _mapper.Map(driverDto, driver);
        
            await _context.SaveChangesAsync();
        
            return driver;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    public async Task<bool> DeleteMyDriver(string driverId)
    {
        var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Id == driverId);

        if (driver == null)
        {
            return false;
        }
        _context.Remove(driver);
        await _context.SaveChangesAsync();
        return true;
    }
}