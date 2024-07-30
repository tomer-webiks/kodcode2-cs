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
        public IActionResult Friend()
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



        // -- VIEW --
        public IActionResult ShoeList()
        {
            return View(Shoes);
        }

        // אני מנסה לקלוט משתנה
        // id
        // שאמור להגיע אלי מהכתובת אינטרנט בפרמטר ה-3
        public IActionResult ShoeDetails(int id)
        {
            Shoe shoe = Shoes.Find(shoe => shoe.Id == id);
            return View(shoe);
        }


        // -- CREATE --
        // מתודה שמציגה דף יצירת נעל
        // GET
        public IActionResult CreateShoe()
        {
            return View();
        }

        // מתודה שמנסה לשמור נעל חדשה במערכת
        [HttpPost]
        public IActionResult CreateShoe(Shoe shoe)
        {
            Shoes.Add(shoe);
            return RedirectToAction("ShoeList");
        }


        // -- UPDATE --
        // מתודה שמציגה דף יצירת נעל
        public IActionResult EditShoe(int id)
        {
            // למצוא נעל ע"פ מזהה שמקבלים בכתובת אינטרנט
            Shoe? shoe = Shoes.Find(shoe => shoe.Id == id);
            return View(shoe);
        }

        // מתודה שמנסה לשמור נעל חדשה במערכת
        [HttpPost]
        public IActionResult UpdateShoe(Shoe shoe)
        {
            // לעדכן נעל
            int index = Shoes.FindIndex(s => s.Id == shoe.Id);
            if (index != -1)
            {
                Shoes[index] = shoe;
            }

            return RedirectToAction("ShoeList");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}