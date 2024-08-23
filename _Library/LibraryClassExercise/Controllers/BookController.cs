using LibraryClassExercise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryClassExercise.Controllers
{
    [Route("Library/{libraryId}/Shelf/{shelfId}/Book")]
    public class BookController : Controller
    {
        // GET: BookController
        public ActionResult List()
        {
            List<IBook> books = new List<IBook>()
            {
                new Book() { Id = 1, Height = 30, Width = 80 },
                new Book() { Id = 2, Height = 35, Width = 85 },
                new Book() { Id = 3, Height = 40, Width = 90 },
                new Book() { Id = 4, Height = 45, Width = 95 },
                new Book() { Id = 5, Height = 50, Width = 100 },
            };

            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        [Route("{bookId}/Edit")]
        public ActionResult Edit([FromRoute] int bookId)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
