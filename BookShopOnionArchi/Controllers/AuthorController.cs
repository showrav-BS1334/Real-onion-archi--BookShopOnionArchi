using BookShopOnionArchi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Entity;
using OA.Service.Interface;

namespace BookShopOnionArchi.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        public AuthorController(IAuthorService authorService, IBookService bookService)
        {
            this.authorService = authorService;
            this.bookService = bookService;
        }

        // GET: AuthorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var author = authorService.GetAuthor(id);
            var books = bookService.GetBooksByAuthor(id).ToList();

            var model = new AuthorViewModel()
            {
                Name = author.Name,
                Id = author.Id,
                ImagePath = author.ImagePath,
                Address = author.Address,
                Books = books,
                Uni = "DUET"
            };
            
            return View(model);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                var newAuthor = new Author
                {
                    Id = author.Id,
                    Name = author.Name,
                    Address = author.Address,
                    Books = author.Books,
                    ImagePath = author.ImagePath,
                };
                authorService.InsertAuthor(newAuthor);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var author = authorService.GetAuthor(id);
            var newAuthor = new AuthorViewModel
            {
                Id = id,
                Name = author.Name,
                Address = author.Address,
                Books = author.Books,
                ImagePath = author.ImagePath,
            };

            if (newAuthor == null)
            {
                return NotFound();
            }
            return View(newAuthor);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                Author newAuthor = new Author
                {
                    Id = author.Id,
                    Name = author.Name,
                    Address = author.Address,
                    ImagePath = author.ImagePath
                };
                authorService.UpdateAuthor(newAuthor);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                authorService.DeleteAuthor(id);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            return View();
        }
    }
}
