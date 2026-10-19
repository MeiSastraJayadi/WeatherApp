using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace WeatherApp;

public class NavButton : Button
{
    public static readonly StyledProperty<BoxShadows> BoxShadowProperty = 
        AvaloniaProperty.Register<NavButton,BoxShadows>(nameof(BoxShadow));
    
    public BoxShadows BoxShadow
    {
        get => GetValue(BoxShadowProperty);
        set => SetValue(BoxShadowProperty, value);
    }

}