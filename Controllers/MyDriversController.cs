using API_Formula1.DTOs;
using API_Formula1.Models;
using API_Formula1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Formula1.Controllers;

[ApiController]
[Route("api/{controller}")]
public class MyDriversController : ControllerBase
{
    private readonly IMyDriversService _myDriversService;

    public MyDriversController(IMyDriversService myDriversService)
    {
        _myDriversService = myDriversService;
    }

    [HttpGet("/GetMyDrivers")]
    public async Task<ActionResult<IEnumerable<Driver>>> GetMyDrivers()
    {
        var drivers = await _myDriversService.GetMyDrivers();
        
        return Ok(drivers);
    }
    
    [HttpGet("/GetDriversById/{id}")]
    public async Task<IActionResult> GetDriversById(string id)
    {
        var driver = await _myDriversService.GetDriverById(id);
        return Ok(driver);
    }
    
    
    [HttpPost]
    [Route("/CreateDriver")]
    public async Task<IActionResult> CreateDriver([FromBody] DriverDTO driverDto)
    {
        try
        {
            var driver = await _myDriversService.CreateMyDriver(driverDto);
            return Ok(driver);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut]
    [Route("/UpdateMyDriver/{driverId}")]
    public async Task<ActionResult<Driver>> UpdateDriver(
        [FromBody] DriverDTO driverDto,
        [FromRoute] string driverId)
    {
        try
        {
            var driver = await _myDriversService.UpdateMyDriver(driverDto, driverId);
            if (driver == null)
            {
                return NotFound($"Driver with ID {driverId} not found.");
            }
            return Ok(driver);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete]
    [Route("/DeleteDriver/{driverId}")]
    public async Task<IActionResult> DeleteDriver([FromRoute] string driverId)
    {
        try
        {
            var deleteMyDriver = await _myDriversService.DeleteMyDriver(driverId);
            return Ok(deleteMyDriver);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}