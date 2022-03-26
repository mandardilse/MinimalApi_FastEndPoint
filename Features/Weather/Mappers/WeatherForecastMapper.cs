using MinimalApi_FastEndPoint.Features.Weather.Contracts.Request;
using MinimalApi_FastEndPoint.Features.Weather.Contracts.Response;
using MinimalApi_FastEndPoint.Features.Entity.Weather;
using FastEndpoints;

namespace MinimalApi_FastEndPoint.Features.Weather.Mappers;

public class WeatherForecastMapper : Mapper<WeatherForecastRequest, WeatherForecastResponse, WeatherForecast>
{
    public override WeatherForecastResponse FromEntity(WeatherForecast e)
    {
        return new WeatherForecastResponse {
            Date = e.Date,
            Summary = e.Summary,
            TemperatureC = e.TemperatureC,
            TemperatureF = e.TemperatureF
        };
    }
}
