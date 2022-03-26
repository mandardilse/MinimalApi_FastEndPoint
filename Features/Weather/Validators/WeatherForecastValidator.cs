using FastEndpoints.Validation;
using MinimalApi_FastEndPoint.Features.Weather.Contracts.Request;

namespace MinimalApi_FastEndPoint.Features.Weather.Validators;

public class WeatherForecastValidator : Validator<WeatherForecastRequest>
{
    public WeatherForecastValidator()
    {
        RuleFor(x => x.Days)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Atleast 1 day!")
            .LessThanOrEqualTo(14)
            .WithMessage("Atmost 15 days!");
    }
}
