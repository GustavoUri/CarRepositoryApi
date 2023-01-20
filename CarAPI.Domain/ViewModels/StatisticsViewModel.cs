namespace CarAPI.Domain.ViewModels;

public class StatisticsViewModel
{
    public int NumberOfRecords { get; set; }
    public DateTime FirstRecordDate { get; set; }
    public DateTime LastRecordDate { get; set; }
    public int OldestReleaseYear { get; set; }
}