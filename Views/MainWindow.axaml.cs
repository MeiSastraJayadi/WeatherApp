using System;
using System.Diagnostics.Tracing;
using Avalonia.Controls;
using Avalonia.Input.Platform;
using WeatherApp.ViewModels;

namespace WeatherApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContextChanged += (_, _) => GetCountryWeather();

        Opened += (_,_) =>
        {
            Console.WriteLine("Window is opened");
        };

        ScalingChanged += (_,_) =>
        {
            Console.WriteLine("Scale change");
        };

    }

    public void GetCountryWeather()
    {
        if (DataContext is not MainViewModel viewModel) return;

        viewModel.CountryWeathers = new()
        {
            new CountryWeather { Country = "Indonesia" }, 
            new CountryWeather { Country = "Malaysia" }, 
            new CountryWeather { Country = "Australia" }
        };
    }

    private void CopyToClipboard(object? sender, EventCommandEventArgs? e)
    {
        TopLevel? windows = GetTopLevel(this);

        if (windows == null) return;

        IClipboard? clipboard = windows.Clipboard;
    }
}