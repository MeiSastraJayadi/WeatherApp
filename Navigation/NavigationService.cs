using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.ViewModels.Pages;

namespace WeatherApp.Navigation;

public partial class NavigationService : ObservableObject, INavigationService
{
    private static readonly IDictionary<AppRoute, Type> Routes = 
        new Dictionary<AppRoute, Type>
        {
          [AppRoute.Home] = typeof(HomeViewModel), 
          [AppRoute.Forecast] = typeof(ForecastViewModel), 
          [AppRoute.Map] = typeof(MapViewModel), 
          [AppRoute.Settings] = typeof(SettingsViewModel)  
        };

    private readonly IServiceProvider _services = null!;

    [ObservableProperty]
    public partial PageViewModelBase? CurrentPage { get; set; }

    [ObservableProperty]
    public partial AppRoute? CurrentRoute { get; set; }

    public async Task NavigateToAsync(AppRoute route, object? parameter = null)
    {
        if (CurrentRoute == route) return;

        PageViewModelBase? page = (PageViewModelBase)_services.GetRequiredService(Routes[route]);

        if (CurrentPage is not null)
        {
            await CurrentPage.OnNavigatedFromAsync();
        }

        CurrentPage = page; 
        CurrentRoute = route;

        await page.OnNavigatedToAsync(parameter);

    }
}
