using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reactive.Linq;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using WeatherApp.Models;

namespace WeatherApp.ViewModels.Pages;

public partial class ForecastViewModel : PageViewModelBase
{
    public IObservable<string> CurrentTime { get; } =
         Observable.Timer(TimeSpan.Zero, TimeSpan.FromMinutes(1))
        .Select(_ =>
            $"{DateTime.Now.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)}");
    
    private static Bitmap LoadImage(string name)
        => new (AssetLoader.Open(new Uri($"avares://WeatherApp/Assets/Icons/{name}.png")));

    [ObservableProperty]
    public partial ObservableCollection<DailyForecast> Forecasts { get; set; } = new()
    {
        new DailyForecast { Day = "Today", Icon = LoadImage("sunny"), MaxTemperature = 31, MinTemperature = 24, Humidity = 10 },  
        new DailyForecast { Day = "Monday", Icon = LoadImage("heavy_rain"), MaxTemperature = 31, MinTemperature = 24, Humidity = 15 },
        new DailyForecast { Day = "Tuesday", Icon = LoadImage("thunderstorm"), MaxTemperature = 31, MinTemperature = 24, Humidity = 20 },
        new DailyForecast { Day = "Wednesday", Icon = LoadImage("heavy_rain"), MaxTemperature = 31, MinTemperature = 24, Humidity = 30 },
        new DailyForecast { Day = "Thursday", Icon = LoadImage("sunny"), MaxTemperature = 31, MinTemperature = 24, Humidity = 10 },  
        new DailyForecast { Day = "Friday", Icon = LoadImage("heavy_rain"), MaxTemperature = 31, MinTemperature = 24, Humidity = 15 },
        new DailyForecast { Day = "Saturday", Icon = LoadImage("thunderstorm"), MaxTemperature = 31, MinTemperature = 24, Humidity = 20 },  
    }; 
}
