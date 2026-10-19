using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
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

    public IObservable<string> CurrentTime { get; } =
        Observable.Interval(TimeSpan.FromSeconds(1))
            .Select(_ => DateTime.Now.ToString("HH:mm:ss"));

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHomeActive))]
    [NotifyPropertyChangedFor(nameof(IsForecastActive))]
    [NotifyPropertyChangedFor(nameof(IsMapActive))]
    [NotifyPropertyChangedFor(nameof(IsSettingActive))]
    public partial string ActivePage { get; set; }

    public bool IsHomeActive => ActivePage == "Home";
    public bool IsForecastActive => ActivePage == "Forecast";
    public bool IsMapActive => ActivePage == "Map";
    public bool IsSettingActive => ActivePage == "Setting";

}
