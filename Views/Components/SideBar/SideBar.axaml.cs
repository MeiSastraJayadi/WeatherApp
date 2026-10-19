using Avalonia.Controls;
using Avalonia.Interactivity;
using WeatherApp.ViewModels;

namespace WeatherApp;

public partial class SideBar : UserControl
{
    public SideBar()
    {
        InitializeComponent();
    }

    private void Click_Button(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not MainViewModel viewModel) return;

        if (sender is Button button)
        {
            viewModel.Greeting = $"You just clicked {button.Content}";
        }
    }

    public void Click_Nav(object? sender, RoutedEventArgs? e)
    {
        if (DataContext is not MainViewModel viewModel) return;

        if (sender is Button button)
        {
            viewModel.ActivePage = $"{button.Content}";
        }

    }
}