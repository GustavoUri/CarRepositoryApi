using CarAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarDirectoryAPI.Controllers;

[ApiController]
public class StatisticsController : Controller
{
    private readonly IStatisticsService _statService;

    public StatisticsController(IStatisticsService statService)
    {
        _statService = statService;
    }
    /// <summary>
    /// Returns cars statistics
    /// </summary>
    /// <remarks>
    ///  
    ///     GET /statistics
    ///     
    ///    
    /// 
    /// </remarks>
    /// <response code="200">Successful</response>
    /// <response code="400">No records in database</response>
    /// <response code="500">Server problem</response>
    [Route("statistics")]
    [HttpGet]
    public IActionResult GetStatistics()
    {
        var result = _statService.GetStatistics();
        return Json(result);
    }
}