using Microsoft.AspNetCore.Mvc;
using MVCShopSimple.DAL;
using MVCShopSimple.Models;
using System.Diagnostics;

namespace MVCShopSimple.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<ShoeController> _logger;

        public HomeController(ShoeDbContext shoeContext, ILogger<ShoeController> logger)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
