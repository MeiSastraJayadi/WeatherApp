using Avalonia;
using Avalonia.Controls;

namespace WeatherApp;

public class WeatherList : ContentControl
{
    public static readonly StyledProperty<string> DayProperty = 
        AvaloniaProperty.Register<WeatherList, string>(nameof(Day), string.Empty);

    public string Day
    {
        get => GetValue(DayProperty);
        set => SetValue(DayProperty, value);
    }
}