using LibraryClassExercise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryClassExercise.Controllers
{
    [Route("Library")]
    public class LibraryController : Controller
    {
        private readonly ILogger<LibraryController> _logger;
        private List<Library> _libraryList = new List<Library>()
            {
                new Library() { Id = 1, Name = "Galil"},
                new Library() { Id = 2, Name = "Great Big Library"},
                new Library() { Id = 3, Name = "Historic Library"},
                new Library() { Id = 4, Name = "Biology Library"},
                new Library() { Id = 5, Name = "Physics Library"}
            };

        public LibraryController(ILogger<LibraryController> logger)
        {
            _logger = logger;
        }

        [Route("List")]
        public IActionResult List()
        {
            return View(_libraryList);
        }

        [Route("Books")]
        public IActionResult Books()
        {
            List<IBook> books = new List<IBook>()
            {
                new Book() { Id = 1, Height = 30, Width = 80 },
                new Book() { Id = 2, Height = 35, Width = 85 },
                new Book() { Id = 3, Height = 40, Width = 90 },
                new Book() { Id = 4, Height = 45, Width = 95 },
                new Book() { Id = 5, Height = 50, Width = 100 },
                new BookSet() { 
                    Id = 23, 
                    books = new List<Book>() {
                        new Book() { Id = 3, Height = 40, Width = 90 },
                        new Book() { Id = 4, Height = 45, Width = 95 },
                    }
                },
                new BookSet() { Id = 23, Height = 55, Width = 120 },
                new BookSet() { Id = 23, Height = 23, Width = 120 },
            };

            return View(books);
        }

        // Action that presents the Library details + List of shelves
        // Expecting ROUTE_PARAMETER called id
        // Data to transfer to VIEW:
        // - Library object (THAT ALREADY CONTAINS a list of Shelves)
        [Route("{id}/Edit")]
        public IActionResult Edit([FromRoute] int id)
        {
            // 1. Find Library object
            Library? library = _libraryList.Find(l => l.Id == id);
            if (library != null)
            {
                // 2. Create Shelves
                library.Shelves = new List<Shelf>()
                {
                    new Shelf() { Id = 1, Height = 30, Width = 80 },
                    new Shelf() { Id = 2, Height = 35, Width = 85 },
                    new Shelf() { Id = 3, Height = 40, Width = 90 },
                    new Shelf() { Id = 4, Height = 45, Width = 95 },
                    new Shelf() { Id = 5, Height = 50, Width = 100 },
                };
            }

            // 3. Return to VIEW
            return View(library);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
