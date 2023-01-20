namespace CarAPI.Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public int ReleaseYear { get; set; }
    public string Body { get; set; }
    public int EnginePower { get; set; }
    public string Transmission { get; set; }
    public string Model { get; set; }
    public string Owner { get; set; }
    public DateTime AddedTime { get; set; }
}