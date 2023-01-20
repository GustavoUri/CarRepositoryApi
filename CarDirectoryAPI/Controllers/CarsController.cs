using CarAPI.Domain.ViewModels;
using CarAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarDirectoryAPI.Controllers;

[ApiController]
public class CarsController : Controller
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }
    /// <summary>
    /// Returns all cars in database
    /// </summary>
    /// <remarks>
    /// 
    ///     
    ///     
    ///  
    ///     GET /cars
    ///     
    ///    
    /// 
    /// </remarks>
    /// <response code="200">Successful</response>
    /// <response code="500">Server problem</response>
    [HttpGet]
    [Route("cars")]
    public IActionResult GetCars()
    {
        var result = _carService.GetCars();
        return Json(result);
    }
    /// <summary>
    /// Returns filtered cars from database
    /// </summary>
    /// <remarks>
    ///  If you don't want to do filtration by some attributes,
    ///  just don't add them
    ///     POST /carsByFilter
    ///     
    ///    
    /// 
    /// </remarks>
    /// <response code="200">Successful</response>
    /// <response code="500">Server problem</response>
    [HttpPost]
    [Route("carsByFilter")]
    public IActionResult GetCarsByFilter(FilterViewModel filter)
    {
        var result = _carService.GetCarsByFilter(filter);
        return Json(result);
    }
    /// <summary>
    /// Adds new car to database
    /// </summary>
    /// <remarks>
    ///  
    ///     POST /addCar
    ///     
    ///    
    /// 
    /// </remarks>
    /// <response code="200">Successful</response>
    /// <response code="500">Server problem</response>
    /// <response code="400">Car number already exists</response>
    [HttpPost]
    [Route("addCar")]
    public IActionResult AddCar(CarViewModel carViewModel)
    {
        _carService.AddCar(carViewModel);
        return Ok();
    }
    /// <summary>
    /// Deletes car from database
    /// </summary>
    /// <remarks>
    ///  
    ///     POST /deleteCar
    ///     
    ///    
    /// 
    /// </remarks>
    /// <response code="200">Successful</response>
    /// <response code="500">Server problem</response>
    /// <response code="400">No car with this id in database</response>
    [HttpPost]
    [Route("deleteCar")]
    public IActionResult DeleteCar(int id)
    {
        _carService.DeleteCar(id);
        return Ok();
    }
    /// <summary>
    /// Returns photo of a car by id
    /// </summary>
    /// <remarks>
    ///  
    ///     GET /carPhoto
    ///     
    ///    
    /// 
    /// </remarks>
    /// <response code="200">Successful</response>
    /// <response code="500">Server problem</response>
    /// <response code="400">No photo by this id in database</response>
    [HttpGet]
    [Route("carPhoto")]
    public async Task<IActionResult> GetCarPhoto(int id)
    {
        var picture = await _carService.GetCarPhotoAsync(id);
        return File(picture, "image/png");
    }
    /// <summary>
    /// Adds photo of a car to database
    /// </summary>
    /// <remarks>
    ///  
    ///     POST /carPhoto
    ///     
    ///    
    /// 
    /// </remarks>
    /// <response code="200">Successful</response>
    /// <response code="500">Server problem</response>
    [HttpPost]
    [Route("carPhoto")]
    public async Task<IActionResult> AddCarPhoto(int id, IFormFile picture)
    {
        await _carService.AddCarPhotoAsync(id, picture);
        return Ok();
    }
    /// <summary>
    /// Returns cae by number
    /// </summary>
    /// <remarks>
    ///  
    ///     GET /carByNumber
    ///     
    ///    
    /// 
    /// </remarks>
    /// <response code="200">Successful</response>
    /// <response code="500">Server problem</response>
    /// <response code="400">No car by this number in database</response>
    [HttpGet]
    [Route("carByNumber")]
    public IActionResult GetCarByNumber(string number)
    {
        var result = _carService.GetCarByNumber(number);
        return Json(result);
    }
}