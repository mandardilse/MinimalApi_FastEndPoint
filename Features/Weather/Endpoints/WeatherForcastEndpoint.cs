using FastEndpoints;
using MinimalApi_FastEndPoint.Features.Entity.Weather;
using MinimalApi_FastEndPoint.Features.Weather.Contracts.Request;
using MinimalApi_FastEndPoint.Features.Weather.Contracts.Response;
using MinimalApi_FastEndPoint.Features.Weather.Mappers;

namespace MinimalApi_FastEndPoint.Features.Weather.Endpoints;

public class WeatherForcastEndpoint : Endpoint<WeatherForecastRequest, List<WeatherForecastResponse>, WeatherForecastMapper>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly ILogger<WeatherForcastEndpoint> _logger;

    public WeatherForcastEndpoint(ILogger<WeatherForcastEndpoint> logger)
    {
        _logger = logger;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("weather/{days}");
        AllowAnonymous();
    }    

    public override async Task HandleAsync(WeatherForecastRequest req, CancellationToken ct)
    {
        _logger.LogInformation("Retriving weather for {Days} days", req.Days);
        var forecasts = Enumerable.Range(1, req.Days).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();

        var response = new List<WeatherForecastResponse>(
            forecasts.Select(x => Map.FromEntity(x))
        );

        await SendAsync(response, cancellation: ct);
    }
}
