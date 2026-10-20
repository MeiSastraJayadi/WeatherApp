using System.Threading.Tasks;
namespace WeatherApp.ViewModels.Pages;

public abstract class PageViewModelBase : ViewModelBase
{
    public virtual Task OnNavigatedToAsync(object? sender) => Task.CompletedTask;
    public virtual Task OnNavigatedFromAsync() => Task.CompletedTask;
}
