using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input.Platform;
using WeatherApp.ViewModels;

namespace WeatherApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContextChanged += async (_, _) => await GetCountryWeather();

        Opened += (_,_) =>
        {
            Console.WriteLine("Window is opened");
        };

        ScalingChanged += (_,_) =>
        {
            Console.WriteLine("Scale change");
        };

    }

    public async Task GetCountryWeather()
    {
        if (DataContext is not MainViewModel viewModel) return;

        viewModel.IsLoading = true;

        await Task.Delay(2000);

        viewModel.CountryWeathers = new()
        {
            new CountryWeather { Country = "Indonesia" }, 
            new CountryWeather { Country = "Malaysia" }, 
            new CountryWeather { Country = "Australia" }
        };

        viewModel.IsLoading = false;
    }

    private void CopyToClipboard(object? sender, EventCommandEventArgs? e)
    {
        TopLevel? windows = GetTopLevel(this);

        if (windows == null) return;

        IClipboard? clipboard = windows.Clipboard;
    }
}