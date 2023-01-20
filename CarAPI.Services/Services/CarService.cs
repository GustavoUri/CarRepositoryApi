using CarAPI.Data.Interfaces;
using CarAPI.Domain.Entities;
using CarAPI.Domain.ViewModels;
using CarAPI.Domain.Exceptions;
using CarAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CarAPI.Services.Services;

public class CarService : ICarService
{
    private readonly IRepository<Car> _carRep;

    public CarService(IRepository<Car> carRep)
    {
        _carRep = carRep;
    }

    public IEnumerable<Car> GetCarsByFilter(FilterViewModel filter)
    {
        var allCars = GetCars();
        if (filter.Brands != null)
        {
            allCars = allCars.Where(car => filter.Brands.Contains(car.Brand));
        }

        if (filter.Colors != null)
        {
            allCars = allCars.Where(car => filter.Colors.Contains(car.Color));
        }

        if (filter.BodyTypes != null)
        {
            allCars = allCars.Where(car => filter.BodyTypes.Contains(car.Body));
        }

        allCars = FiltrateByReleaseYear(allCars, filter);

        allCars = FiltrateByEnginePower(allCars, filter);

        if (filter.Owner is not null)
        {
            allCars = allCars.Where(car => car.Owner == filter.Owner);
        }

        if (filter.Models != null)
        {
            allCars = allCars.Where(car => filter.Models.Contains(car.Model));
        }

        return allCars;
    }

    private static IEnumerable<Car> FiltrateByReleaseYear(IEnumerable<Car> source, FilterViewModel filter)
    {
        if (filter.MinReleaseYear is not null)
        {
            source = source.Where(car => car.ReleaseYear >= filter.MinReleaseYear);
        }

        if (filter.MaxReleaseYear is not null)
        {
            source = source.Where(car => car.ReleaseYear <= filter.MaxReleaseYear);
        }

        return source;
    }

    private static IEnumerable<Car> FiltrateByEnginePower(IEnumerable<Car> source, FilterViewModel filter)
    {
        if (filter.MinEnginePower is not null)
        {
            source = source.Where(car => car.EnginePower >= filter.MinEnginePower);
        }

        if (filter.MaxEnginePower is not null)
        {
            source = source.Where(car => car.EnginePower <= filter.MaxEnginePower);
        }

        return source;
    }

    public void AddCar(CarViewModel carModel)
    {
        if (carModel.Number.Length != 8)
            throw new BadRequestException("Wrong length of number, must be 8 symbols");
        var existCar = _carRep.GetAll().FirstOrDefault(car => car.Number == carModel.Number.ToUpper());
        if (existCar != null)
            throw new BadRequestException("Car with this number already exists");
        var car = new Car()
        {
            Body = carModel.BodyType,
            Brand = carModel.Brand,
            Color = carModel.Color,
            Transmission = carModel.TransmissionType,
            EnginePower = carModel.EnginePower,
            Number = carModel.Number.ToUpper(),
            ReleaseYear = carModel.ReleaseYear,
            AddedTime = DateTime.Now,
            Model = carModel.Model,
            Owner = carModel.Owner
        };
        _carRep.Create(car);
        _carRep.SaveChanges();
    }

    public void DeleteCar(int id)
    {
        _carRep.Delete(id);
        _carRep.SaveChanges();
    }

    public IEnumerable<Car> GetCars()
    {
        var allCars = _carRep.GetAll();
        return allCars;
    }

    public Car GetCarByNumber(string number)
    {
        var cars = GetCars();
        var car = cars.FirstOrDefault(car => car.Number == number.ToUpper());
        if (car == null)
            throw new BadRequestException("No cars with this number");
        return car;
    }

    public async Task AddCarPhotoAsync(int carId, IFormFile photo)
    {
        _carRep.GetById(carId);
        var path = $"Pictures/CarPhotos/{carId}";
        await using var stream = new FileStream(path, FileMode.Create);
        await photo.CopyToAsync(stream);
    }

    public async Task<byte[]> GetCarPhotoAsync(int carId)
    {
        var path = $"Pictures/CarPhotos/{carId}";
        if (!File.Exists(path))
            throw new BadRequestException("No photo by this id");

        var picture = await File.ReadAllBytesAsync(path);
        return picture;
    }
}