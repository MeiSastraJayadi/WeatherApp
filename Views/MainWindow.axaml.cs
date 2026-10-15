using System;
using System.Diagnostics.Tracing;
using Avalonia.Controls;
using Avalonia.Input.Platform;

namespace WeatherApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Opened += (_,_) =>
        {
            Console.WriteLine("Window is opened");
        };

        ScalingChanged += (_,_) =>
        {
            Console.WriteLine("Scale change");
        };
    }

    private void CopyToClipboard(object? sender, EventCommandEventArgs? e)
    {
        TopLevel? windows = GetTopLevel(this);

        if (windows == null) return;

        IClipboard? clipboard = windows.Clipboard;
    }
}