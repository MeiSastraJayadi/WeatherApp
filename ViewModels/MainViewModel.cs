using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to WeatherApp!";

    [ObservableProperty]
    public partial ObservableCollection<CountryWeather> CountryWeathers { get; set; } = new();

    [ObservableProperty]
    public partial bool IsLoading { get; set; }

}
