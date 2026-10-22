using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reactive.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

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

}
