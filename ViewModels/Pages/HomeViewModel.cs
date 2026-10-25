using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reactive.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WeatherApp.Models;

namespace WeatherApp.ViewModels.Pages;

public partial class HomeViewModel : PageViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { set; get; } = "Welcome to Home";

    [ObservableProperty]
    public partial ObservableCollection<CountryWeather> CountryWeathers { get; set; } = new();

    [ObservableProperty]
    public partial bool IsLoading { get; set; }

    public IObservable<string> CurrentTime { get; } =
         Observable.Timer(TimeSpan.Zero, TimeSpan.FromMinutes(1))
        .Select(_ =>
            $"Today, {DateTime.Now.ToString("dd MMM yyyy - HH:mm", CultureInfo.InvariantCulture)}");

    public override async Task OnNavigatedToAsync(object? parameter)
    {
        if (CountryWeathers.Count > 0) return;

        IsLoading = true;
        await Task.Delay(2000);

        CountryWeathers = new()
        {
            new CountryWeather { Country = "Indonesia" },
            new CountryWeather { Country = "Malaysia" },
            new CountryWeather { Country = "Australia" }
        };

        IsLoading = false;
    }

    [ObservableProperty]
    public partial ObservableCollection<DailyForecast> Forecasts { get; set; } = new()
    {
      new DailyForecast { Day = "Today", Icon = "avares://WeatherApp/Assets/Icons/sunny.png", MaxTemperature = 31, MinTemperature = 24 },  
      new DailyForecast { Day = "Monday", Icon = "avares://WeatherApp/Assets/Icons/heavy_rain.png", MaxTemperature = 31, MinTemperature = 24 },
      new DailyForecast { Day = "Tuesday", Icon = "avares://WeatherApp/Assets/Icons/thunderstorm.png", MaxTemperature = 31, MinTemperature = 24 },
      new DailyForecast { Day = "Wednesday", Icon = "avares://WeatherApp/Assets/Icons/sunny.png", MaxTemperature = 31, MinTemperature = 24 }      
    };

}
