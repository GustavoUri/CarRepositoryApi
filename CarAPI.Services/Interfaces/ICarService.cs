using CarAPI.Domain.Entities;
using CarAPI.Domain.ViewModels;
using Microsoft.AspNetCore.Http;

namespace CarAPI.Services.Interfaces;

public interface ICarService
{
    IEnumerable<Car> GetCarsByFilter(FilterViewModel filter);
    void AddCar(CarViewModel car);
    void DeleteCar(int id);
    IEnumerable<Car> GetCars();
    Car GetCarByNumber(string number);
    Task AddCarPhotoAsync(int carId, IFormFile photo);
    Task<byte[]> GetCarPhotoAsync(int carId);
}