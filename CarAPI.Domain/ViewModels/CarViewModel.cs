using System.ComponentModel.DataAnnotations;

namespace CarAPI.Domain.ViewModels;

public class CarViewModel
{
    public string Number { get; set; }
    [StringLength(30, MinimumLength = 3, ErrorMessage = "The length of the string should be from 3 to 30 characters")]
    public string Brand { get; set; }
    [StringLength(10, MinimumLength = 3, ErrorMessage = "The length of the string should be from 3 to 10 characters")]
    public string Color { get; set; }
    [Range(1900, 2023, ErrorMessage = "Invalid value")]
    public int ReleaseYear { get; set; }
    [StringLength(10, MinimumLength = 3, ErrorMessage = "The length of the string should be from 3 to 10 characters")]
    public string BodyType { get; set; }
    [Range(1, 3000, ErrorMessage = "Invalid value")]
    public int EnginePower { get; set; }
    public string TransmissionType { get; set; }
    [StringLength(15, MinimumLength = 3, ErrorMessage = "The length of the string should be from 3 to 15 characters")]
    public string Model { get; set; }
    [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of the string should be from 3 to 20 characters")]
    public string Owner { get; set; }
}