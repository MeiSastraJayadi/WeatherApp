namespace WeatherApp.Models;

public class DailyForecast
{
    public string Day { get; init; } = null!;
    public string Icon { get; init; } = null!; 
    public int MaxTemperature { get; init; }
    public int MinTemperature { get; init; } 
}
