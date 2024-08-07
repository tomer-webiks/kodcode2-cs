using Chat.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Chat()
        {
            var model = new ChatModel
            {
                Messages = new List<string>() // Initialize with empty list or actual data
            };

            return View(model);
        }
    }
}
