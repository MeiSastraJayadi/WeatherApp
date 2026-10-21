using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Navigation;
using WeatherApp.ViewModels;
using WeatherApp.ViewModels.Pages;
using WeatherApp.Views;

namespace WeatherApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<ForecastViewModel>();
            services.AddSingleton<MapViewModel>();
            services.AddSingleton<SettingsViewModel>();

            services.AddSingleton<MainViewModel>();

            ServiceProvider provider = services.BuildServiceProvider();
            MainViewModel mainViewModel = provider.GetRequiredService<MainViewModel>();

            var window = new MainWindow
            {
                DataContext = mainViewModel
            };

            window.Opened += async (_, _) => await mainViewModel.InitializeAsync();

            desktop.MainWindow = window;
            desktop.ShutdownRequested += (_, _) => provider.Dispose();
        }

        base.OnFrameworkInitializationCompleted();
    }
}