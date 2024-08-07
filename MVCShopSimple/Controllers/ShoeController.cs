using Microsoft.AspNetCore.Mvc;
using MVCShopSimple.DAL;
using MVCShopSimple.Models;
using System.Diagnostics;

namespace MVCShopSimple.Controllers
{
    public class ShoeController : Controller
    {
        private readonly ILogger<ShoeController> _logger;
        private readonly ShoeDbContext _shoeContext;

        public ShoeController(ShoeDbContext shoeContext, ILogger<ShoeController> logger)
        {
            _logger = logger;
            _shoeContext = shoeContext;
        }

        [Route("/shoe")]
        public IActionResult Index()
        {
            //var products = _shoeContext.Shoes.Include(p => p.Images).ToList();
            //return View(products);
            return View();
        }
    }
}
