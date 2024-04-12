using EasyPieces.Attributes;
using EasyPieces.Builders;
using Microsoft.AspNetCore.Mvc;

namespace EasyPieces.TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EasyAccess("Weather")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("TestWorkflow")]
        public async Task<IActionResult> TestWorkflowAsync()
        {
            try
            {
                List<WorkflowTask> workflow = new WorkflowBuilder()
                .WithTask(new WorkflowTask("Process Method", WeatherForecast.Process))
                .WithTask(new WorkflowTask("Process async Method", WeatherForecast.ProcessAsync))
                .Build();

                var result = await workflow.ExecuteAsync();
                if (result.IsCompletedSuccessfully)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                throw;
            }
        }
    }
}
