using Avalonia.Media.Imaging;

namespace WeatherApp.Models;

public class DailyForecast
{
    public string Day { get; init; } = null!;
    public Bitmap Icon { get; init; } = null!; 
    public int MaxTemperature { get; init; }
    public int MinTemperature { get; init; } 
}
