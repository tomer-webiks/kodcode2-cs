using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Friends_Img.DAL;
using My_Friends_Img.Models;
using System.Diagnostics;

namespace My_Friends_Img.Controllers
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
            return View(Data.Get.Friends.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(Friend friend)
        {
            if (friend == null) return RedirectToAction("index");
            Data.Get.Friends.Add(friend);
            Data.Get.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int id) { 
            if(id == null) return RedirectToAction("index");
            Friend friend = Data.Get.Friends.Include(f=>f.Images).ToList().Find(fri => fri.ID == id);
            if (friend == null) return RedirectToAction("Index");
            return View(friend);
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
