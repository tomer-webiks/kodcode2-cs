using Microsoft.AspNetCore.Mvc;
using MVCShoeShop.Models;
using System.Diagnostics;
namespace MVCShoeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<Shoe> Shoes = new List<Shoe>()
        {
            new Shoe()
            {
                Id = 1,
                Color = "Black",
                Size = 45
            },
            new Shoe()
            {
                Id = 2,
                Color = "White",
                Size = 35
            }
        };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Profile()
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