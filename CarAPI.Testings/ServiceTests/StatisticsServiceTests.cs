using System;
using System.Collections.Generic;
using CarAPI.Data.Interfaces;
using CarAPI.Domain.Entities;
using CarAPI.Domain.ViewModels;
using CarAPI.Services.Services;
using Moq;
using Xunit;

namespace CarAPI.Testings.ServiceTests;

public class StatisticsServiceTests
{
    [Fact]
    public void GetCarsWithReleaseYearFilter()
    {
        // Arrange
        var mock = new Mock<IRepository<Car>>();
        mock.Setup(repo => repo.GetAll()).Returns(GetCars());
        var statService = new StatisticsService(mock.Object);

        // Act
        var result = statService.GetStatistics();

        // Assert
        Assert.True(result.NumberOfRecords == 4);
        Assert.True(result.OldestReleaseYear == 1950);
    }

    private List<Car> GetCars()
    {
        var cars = new List<Car>
        {
            new Car()
            {
                ReleaseYear = 1950,
            },
            new Car() {ReleaseYear = 1990},
            new Car() {ReleaseYear = 1995},
            new Car() {ReleaseYear = 2018}
        };
        return cars;
    }
}