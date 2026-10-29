using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherApp.ViewModels.Pages;

public partial class MapViewModel : PageViewModelBase
{
    [ObservableProperty]
    public partial double SelectedLatitude { get; set; } = -6.2088;

    [ObservableProperty]
    public partial double SelectedLongitude { get; set; } = 106.8456;    
}
