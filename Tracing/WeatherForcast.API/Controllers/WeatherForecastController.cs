using Microsoft.AspNetCore.Mvc;

namespace WeatherForcast.API.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clinet = _httpClientFactory.CreateClient();
            
            //calling sample api , you can use weather api
            var response = await
                clinet.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

            return Ok();
        }


        [HttpGet]
        public IActionResult SayHello()
        {
            return Ok("hello");
        }
    }
}
