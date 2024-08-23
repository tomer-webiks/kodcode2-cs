using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCShoeShop.DAL;
using MVCShoeShop.Models;
using MVCShoeShop.ViewModels;
using System.Diagnostics;

namespace MVCShoeShop.Controllers
{
    public class ShoeController: Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShoeDbContext _shoeContext;
        public ShoeController(ShoeDbContext shoeContext, ILogger<HomeController> logger)
        {
            _shoeContext = shoeContext;
            _logger = logger;
        }


        // -- VIEW --
        public IActionResult List()
        {
            var shoes = _shoeContext.Shoes.Include(s => s.Images)?.ToList();
            return View(shoes);
        }

        // אני מנסה לקלוט משתנה
        // id
        // שאמור להגיע אלי מהכתובת אינטרנט בפרמטר ה-3
        public IActionResult Details(int id)
        {
            Shoe? shoe = _shoeContext.Shoes.Find(id);
            return View(shoe);
        }


        // -- CREATE --
        // מתודה שמציגה דף יצירת נעל
        // GET
        [Route("/Shoes/New")]
        public IActionResult New()
        {
            ShoeWithCategories sc = new ShoeWithCategories()
            {
                Shoe = new Shoe(),
                Categories = _shoeContext.Categories.ToList()
            };
            return View(sc);
        }

        // מתודה שמנסה לשמור נעל חדשה במערכת
        [HttpPost]
        [Route("/Shoes/Create")]
        public IActionResult Create(int? SelectedCategoryId, Shoe shoe, List<IFormFile> imageFiles)
        {
            // Create Image objects - proper
            if (imageFiles != null && imageFiles.Count > 0)
            {
                foreach (var file in imageFiles)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        var image = new Image
                        {
                            ImageData = memoryStream.ToArray(),
                            ContentType = file.ContentType
                        };
                        shoe.Images.Add(image);
                    }
                }
            }

            if (SelectedCategoryId != null)
            {
                Category category = _shoeContext.Categories.Find(SelectedCategoryId);
                shoe.Category = category;
            }

            _shoeContext.Shoes.Add(shoe);
            _shoeContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/Shoes/{shoeId}/Images/{imageId}")]
        public IActionResult DeleteImage([FromRoute] int shoeId, [FromRoute] int imageId)
        {
            var image = _shoeContext.Images.Find(imageId);
            if (image != null)
            {
                _shoeContext.Images.Remove(image);
                _shoeContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


        // -- UPDATE --
        // מתודה שמציגה דף יצירת נעל
        [HttpGet]
        [Route("/Shoes/Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            // למצוא נעל ע"פ מזהה שמקבלים בכתובת אינטרנט
            var shoe = await _shoeContext.Shoes.Include(s => s.Images).FirstOrDefaultAsync(p => p.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }
            return View(shoe);
        }

        // מתודה שמנסה לשמור נעל חדשה במערכת
        [HttpPost]
        [Route("/Shoes/Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] Shoe shoe, List<IFormFile> imageFiles)
        {
            if (id != shoe.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _shoeContext.Update(shoe);
                await _shoeContext.SaveChangesAsync();

                if (imageFiles != null && imageFiles.Count > 0)
                {
                    foreach (var file in imageFiles)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            var image = new Image
                            {
                                ImageData = memoryStream.ToArray(),
                                ContentType = file.ContentType
                            };
                            _shoeContext.Images.Add(image);
                        }
                    }
                    await _shoeContext.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(shoe);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}