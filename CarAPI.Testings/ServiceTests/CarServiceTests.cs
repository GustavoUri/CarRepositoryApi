using System;
using System.Collections.Generic;
using CarAPI.Data.Interfaces;
using CarAPI.Domain.Entities;
using CarAPI.Domain.ViewModels;
using CarAPI.Services.Services;
using Moq;
using Xunit;

namespace CarAPI.Testings.ServiceTests;

public class CarServiceTests
{
    [Fact]
    public void GetCarsWithBrandsFilter()
    {
        // Arrange
        var mock = new Mock<IRepository<Car>>();
        mock.Setup(repo => repo.GetAll()).Returns(GetBrandTestCars());
        var carService = new CarService(mock.Object);

        // Act
        var filter = new FilterViewModel()
        {
            Brands = new List<string>() {"Ford"}
        };
        var result = carService.GetCarsByFilter(filter);

        // Assert
        Assert.Contains(result, car => car.Brand == "Ford");
    }

    private List<Car> GetBrandTestCars()
    {
        var cars = new List<Car>
        {
            new Car() {Brand = "Ford",},
            new Car() {Brand = "Ford",},
            new Car() {Brand = "Audi",},
            new Car() {Brand = "Maco",}
        };
        return cars;
    }
    
    [Fact]
    public void GetCarsWithReleaseYearFilter()
    {
        // Arrange
        var mock = new Mock<IRepository<Car>>();
        mock.Setup(repo => repo.GetAll()).Returns(GetReleaseYearCars());
        var carService = new CarService(mock.Object);

        // Act
        var filter = new FilterViewModel()
        {
            MinReleaseYear = 1991,
            MaxReleaseYear = 2018
        };
        var result = carService.GetCarsByFilter(filter);

        // Assert
        Assert.Contains(result, car => car.ReleaseYear <= filter.MaxReleaseYear && car.ReleaseYear >= filter.MinReleaseYear);
    }

    private List<Car> GetReleaseYearCars()
    {
        var cars = new List<Car>
        {
            new Car() {ReleaseYear = 1950},
            new Car() {ReleaseYear = 1990},
            new Car() {ReleaseYear = 1995},
            new Car() {ReleaseYear = 2018}
        };
        return cars;
    }
    
}