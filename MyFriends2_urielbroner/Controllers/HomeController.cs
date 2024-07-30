using Microsoft.AspNetCore.Mvc;
using MyFriends2.DataLayer;
using MyFriends2.Models;
using MyFriends2.Service;
using System.Diagnostics;

namespace MyFriends2.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
           
            _logger = logger;
        }

        //יצירת פונקציה להוספת חבר
        public IActionResult Create()
        {
            return View(new Friend());
        }

        public IActionResult Index()
        {
            List<Friend> friends = DL.Get.Friends.ToList();

            return View(friends);
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
