using System.ComponentModel.DataAnnotations;

namespace CarAPI.Domain.ViewModels;

public class FilterViewModel
{
    public IEnumerable<string>? Brands { get; set; }
    public IEnumerable<string>? Colors { get; set; }
    public IEnumerable<string>? BodyTypes { get; set; }

    [Range(1, 3000, ErrorMessage = "Invalid value")]
    public int? MinEnginePower { get; set; }

    [Range(1, 3000, ErrorMessage = "Invalid value")]
    public int? MaxEnginePower { get; set; }

    [Range(1900, 2023, ErrorMessage = "Invalid value")]
    public int? MinReleaseYear { get; set; }

    [Range(1900, 2023, ErrorMessage = "Invalid value")]
    public int? MaxReleaseYear { get; set; }

    public IEnumerable<string>? TransmissionTypes { get; set; }

    [StringLength(15, MinimumLength = 3, ErrorMessage = "The length of the string should be from 3 to 15 characters")]
    public string? Owner { get; set; }

    public IEnumerable<string>? Models { get; set; }
}