using WebApplication2.Services;
using WebApplication2.Models;
using System.Globalization;

public class EarthquakeGeneratorService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly Random _random = new Random();

    public EarthquakeGeneratorService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var earthquakeService = scope.ServiceProvider.GetRequiredService<EarthquakeService>();

                var newEarthquake = new Earthquake
                {
                    Magnitude = RandomMagnitude(),
                    Coordinates = RandomCoordinates(),
                    Date = DateTime.UtcNow
                };

                earthquakeService.Add(newEarthquake);
            }

            await Task.Delay(10000, stoppingToken);
        }
    }

    // Методы RandomMagnitude и RandomCoordinates


private float RandomMagnitude()
    {
        // Генерация случайной магнитуды, например, от 1.0 до 10.0
        return (float)(_random.NextDouble() * 9.0 + 1.0);
    }

    private string RandomCoordinates()
    {
        var culture = CultureInfo.InvariantCulture;

        // Генерация случайных координат
        double latitude = _random.NextDouble() * 180 - 90;
        double longitude = _random.NextDouble() * 360 - 180;

        // Форматирование строки с использованием заданной культуры
        return $"{latitude.ToString(culture)},{longitude.ToString(culture)}";
    }
}
