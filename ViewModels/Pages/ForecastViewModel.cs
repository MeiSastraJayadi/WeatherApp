using System;
using System.Globalization;
using System.Reactive.Linq;

namespace WeatherApp.ViewModels.Pages;

public partial class ForecastViewModel : PageViewModelBase
{
    public IObservable<string> CurrentTime { get; } =
         Observable.Timer(TimeSpan.Zero, TimeSpan.FromMinutes(1))
        .Select(_ =>
            $"{DateTime.Now.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)}");
}
