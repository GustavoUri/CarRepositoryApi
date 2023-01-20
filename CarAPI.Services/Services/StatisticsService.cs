using CarAPI.Data.Interfaces;
using CarAPI.Domain.Entities;
using CarAPI.Domain.Exceptions;
using CarAPI.Domain.ViewModels;
using CarAPI.Services.Interfaces;

namespace CarAPI.Services.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IRepository<Car> _repository;

    public StatisticsService(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public StatisticsViewModel GetStatistics()
    {
        if (_repository.GetAll().Count() == 0)
            throw new BadRequestException("No records in database");
        var statistics = new StatisticsViewModel
        {
            NumberOfRecords = _repository.GetAll().Count(),
            FirstRecordDate = _repository
                .GetAll().OrderBy(car => car.AddedTime)
                .First().AddedTime,
            LastRecordDate = _repository.GetAll()
                .OrderByDescending(car => car.AddedTime).First().AddedTime,
            OldestReleaseYear = _repository.GetAll()
                .OrderBy(car => car.ReleaseYear).First().ReleaseYear
        };
        return statistics;
    }
}