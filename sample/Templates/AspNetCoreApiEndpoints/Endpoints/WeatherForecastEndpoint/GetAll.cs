using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AspNetCoreApiEndpoints.Endpoints.WeatherForecastEndpoint;

public class GetAll : EndpointBaseSync
  .WithoutRequest
  .WithActionResult<IEnumerable<WeatherForecast>>
{
  private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

  [HttpGet("api/weatherforecasts")]
  [SwaggerOperation(
    Summary = "List all Weather Forecasts",
    Description = "List all Weather Forecasts",
    OperationId = "Weather.List",
    Tags = new[] { "WeatherForecastEndpoint" }
    )]
  public override ActionResult<IEnumerable<WeatherForecast>> Handle()
  {
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = DateTime.Now.AddDays(index),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })
            .ToArray();
  }
}
