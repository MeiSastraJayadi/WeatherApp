using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Navigation;

namespace WeatherApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    
    public INavigationService Navigation { get; }

    public MainViewModel(INavigationService navigation)
    {
        Navigation = navigation;
    }

    [RelayCommand]
    private Task NavigateAsync(AppRoute route)
        => Navigation.NavigateToAsync(route);

    public Task InitializeAsync()
        => Navigation.NavigateToAsync(AppRoute.Home);

}
