using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace WeatherApp;

public class NavButton : Button
{
    public static readonly StyledProperty<BoxShadows> BoxShadowProperty = 
        AvaloniaProperty.Register<NavButton,BoxShadows>(nameof(BoxShadow));
    
    public static readonly StyledProperty<Geometry?> IconProperty = 
        AvaloniaProperty.Register<NavButton, Geometry?>(nameof(Icon));

    public BoxShadows BoxShadow
    {
        get => GetValue(BoxShadowProperty);
        set => SetValue(BoxShadowProperty, value);
    }

    public Geometry? Icon
    {
        get => GetValue(IconProperty); 
        set => SetValue(IconProperty, value);
    }

}