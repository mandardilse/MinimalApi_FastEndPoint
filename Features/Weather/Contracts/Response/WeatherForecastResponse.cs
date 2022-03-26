namespace MinimalApi_FastEndPoint.Features.Weather.Contracts.Response;

public class WeatherForecastResponse
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF {get; set;}

    public string? Summary { get; set; }
}
