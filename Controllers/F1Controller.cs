using API_Formula1.DTOs;
using API_Formula1.Models;
using API_Formula1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Formula1.Controllers;

[ApiController]
[Route("api/{controller}")]
public class F1Controller : ControllerBase
{
    private readonly IF1Service _f1Service;

    public F1Controller(IF1Service f1Service)
    {
        _f1Service = f1Service;
    }

    [HttpGet]
    [Route("/GetDriversByYear/{year}")]
    public async Task<IActionResult> GetDriversByYear([FromRoute] int year)
    {
        try
        {
            var driversByYear = await _f1Service.GetDriversByYearAsync(year);
            return Ok(driversByYear);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("/GetStandingsByDate/{year}/{round}")]
    public async Task<IActionResult> GetStandingsByDate([FromRoute] int year, int round)
    {
        try
        {
            var driverStandings = await _f1Service.GetStandingsByRound(year, round);
        
            return Ok(driverStandings);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

}