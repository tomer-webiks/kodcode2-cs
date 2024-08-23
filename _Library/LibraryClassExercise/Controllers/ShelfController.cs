using LibraryClassExercise.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryClassExercise.Models;

namespace LibraryClassExercise.Controllers
{
    [Route("Library/{libraryId}/Shelf")]
    public class ShelfController : Controller
    {
        private List<Library> _libraryList = new List<Library>()
            {
                new Library() { Id = 1, Name = "Galil"},
                new Library() { Id = 2, Name = "Great Big Library"},
                new Library() { Id = 3, Name = "Historic Library"},
                new Library() { Id = 4, Name = "Biology Library"},
                new Library() { Id = 5, Name = "Physics Library"}
            };

        // GET: ShelvesController
        public ActionResult List()
        {
            return View();
        }

        // GET: ShelvesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShelvesController/Create
        // Take into account that the VIEW must receive:
        // - Shelf object
        // - Library Id
        // 
        // 2 Modes:
        // - Create new (blank)
        // - Create new (failed validations - existing object)
        [Route("Create")]
        public ActionResult Create([FromRoute] int libraryId, [FromRoute] int shelfId)
        {
            // 1. Completely first time - NEW object
            LibraryShelf ls = new LibraryShelf()
            {
                // Extract id from Route
                Shelf = new Shelf(),
                LibraryId = libraryId
            };

            // 2. Second time, after validations
            // ...

            return View(ls);
        }

        // POST: ShelvesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([FromRoute] int libraryId)
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

        // GET: ShelvesController/Edit/5
        [Route("{shelfId}/Edit")]
        public ActionResult Edit([FromRoute] int libraryId, [FromRoute] int shelfId)
        {
            Library? library = _libraryList.Find(l => l.Id == libraryId);
            Shelf? shelf = null;

            if (library != null)
            {
                // 2. Create dummy shelves
                library.Shelves = new List<Shelf>()
                {
                    new Shelf() { Id = 1, Height = 30, Width = 80 },
                    new Shelf() { Id = 2, Height = 35, Width = 85 },
                    new Shelf() { Id = 3, Height = 40, Width = 90 },
                    new Shelf() { Id = 4, Height = 45, Width = 95 },
                    new Shelf() { Id = 5, Height = 50, Width = 100 },
                };

                // 3. Craete dummy books
                shelf = library.Shelves.Find(s => s.Id == shelfId);
                if (shelf != null)
                {
                    shelf.Library = library;
                    shelf.Books = new List<Book>()
                    {
                        new Book() { Id = 1, Height = 30, Width = 80 },
                        new Book() { Id = 2, Height = 35, Width = 85 },
                        new Book() { Id = 3, Height = 40, Width = 90 },
                        new Book() { Id = 4, Height = 45, Width = 95 },
                        new Book() { Id = 5, Height = 50, Width = 100 },
                    };
                }
                
            }

            return View(shelf);
        }

        // POST: ShelvesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{shelfId}/Update")]
        public ActionResult Update(int id, IFormCollection collection)
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

        // GET: ShelvesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShelvesController/Delete/5
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
