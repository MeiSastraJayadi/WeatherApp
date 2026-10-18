using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace WeatherApp;

public class Card : ContentControl
{
    public static readonly StyledProperty<BoxShadows> BoxShadowProperty = 
        AvaloniaProperty.Register<Card, BoxShadows>(nameof(BoxShadow));

    public BoxShadows BoxShadow
    {
        get => GetValue(BoxShadowProperty);
        set => SetValue(BoxShadowProperty, value);
    }
}