using Microsoft.AspNetCore.Mvc;
using Test_Pulsar.Api.Events;
using Test_Pulsar.Shared.Abstractions.Messaging;

namespace Test_Pulsar.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMessagePublisher _messagePublisher;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMessagePublisher messagePublisher)
    {
        _logger = logger;
        _messagePublisher = messagePublisher;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var integrationEvent = new UserCreated("rafi.genius.cs@gmail.com", "Muhammed Rafi", "12345");
        await _messagePublisher.PublishAsync<UserCreated>("user-created", integrationEvent);
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}