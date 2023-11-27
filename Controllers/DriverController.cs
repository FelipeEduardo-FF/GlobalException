using GlobalErrorApp.Exceptions;
using GlobalErrorApp.Models;
using GlobalErrorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IDriverService _driverService;

    public DriversController(ILogger<WeatherForecastController> logger, IDriverService driverService)
    {
        _logger = logger;
        this._driverService = driverService;
    }
    [HttpGet]
    public async Task<IActionResult> DriverList()
    {
        var drivers = await _driverService.GetDrivers();
        return Ok(drivers);
    }
    [HttpPost]
    public async Task<IActionResult> AddDriver(Driver driver)
    {
        var result = await _driverService.AddDriver(driver);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDriver(Driver driver)
    {
        var result = await _driverService.UpdateDriver(driver);
        return Ok(result);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetDriverById(int Id)
    {
        var result = await _driverService.GetDriverId(Id);

        if(result is null)
        {// return NotFound();
            throw new NotFoundException("The id is an invalid id");
        }

        return Ok(result);
    }

}
