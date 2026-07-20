using FullStack_BrianBuenJA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FullStack_BrianBuenJA.Services;

namespace FullStack_BrianBuenJA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGreetingService _greetingService;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IGreetingService greetingService, IConfiguration configuration)
        {
            _logger = logger;
            _greetingService = greetingService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.Greeting = _greetingService.GetGreeting();
            ViewBag.CompanyName = _configuration["AppSettings:CompanyName"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
