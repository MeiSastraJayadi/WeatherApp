using System.Threading.Tasks;
using System.ComponentModel;
using WeatherApp.ViewModels.Pages;

namespace WeatherApp.Navigation;

public interface INavigationService : INotifyPropertyChanged
{

    PageViewModelBase? CurrentPage { get; }
    AppRoute? CurrentRoute { get; }

    Task NavigateToAsync(AppRoute? route, object? parameter = null);

}
