using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.API.Controllers
{
    public class WeatherForecast : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
