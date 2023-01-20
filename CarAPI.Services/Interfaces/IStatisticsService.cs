using CarAPI.Domain.ViewModels;

namespace CarAPI.Services.Interfaces;

public interface IStatisticsService
{
    StatisticsViewModel GetStatistics();
}