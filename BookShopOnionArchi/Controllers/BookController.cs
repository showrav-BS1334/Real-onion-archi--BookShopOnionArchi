using BookShopOnionArchi.Models;
using Microsoft.AspNetCore.Mvc;
using OA.Entity;
using OA.Service.Interface;

namespace BookShopOnionArchi.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        public BookController(IAuthorService authorService, IBookService bookService) 
        {
            this.authorService = authorService;
            this.bookService = bookService;
        }

        // GET: BookController
        public ActionResult Index()
        {
            List<BookViewModel> model = new List<BookViewModel>();
            var books = bookService.GetBooks();
            foreach (var book in books)
            {
                BookViewModel modelItem = new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    CoverPath = book.CoverPath,
                    Language = book.Language,
                    AuthorId = book.AuthorId,
                    Author = authorService.GetAuthor(book.AuthorId)
                };
                model.Add(modelItem);
            }
            return View(model);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var book = bookService.GetBook(id);
            BookViewModel model = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                CoverPath = book.CoverPath,
                Language = book.Language,
                AuthorId = book.AuthorId,
                Author = authorService.GetAuthor(book.AuthorId)
            };
            return View(model);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var authors = authorService.GetAuthors().ToList();
            ViewBag.Authors = authors;
            var model = new BookViewModel();
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel book)
        {
            if (ModelState.IsValid || book != null)
            {
                Book newBook = new Book
                {
                    Title = book.Title,
                    CoverPath = book.CoverPath,
                    Language = book.Language,
                    AuthorId = book.AuthorId
                };

                bookService.InsertBook(newBook);
                return RedirectToAction("Index", "Book");
            }
            return View();
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            //authors and book details send kora lagbe
            //viewModel use kore korbo
            var authors = authorService.GetAuthors().ToList();
            var book = bookService.GetBook(id);
            BookUpdateViewModel model = new BookUpdateViewModel
            {
                Book = book,
                AuthorList = authors
            };
            return View(model);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookUpdateViewModel obj, int authorId)
        {
            if (ModelState.IsValid || obj != null)
            {
                Book newBook = new Book
                {
                    Id = obj.Book.Id,
                    Title = obj.Book.Title,
                    CoverPath = obj.Book.CoverPath,
                    Language = obj.Book.Language,
                    AuthorId = authorId
                };
                bookService.UpdateBook(newBook);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid || id > 0)
            {
                bookService.DeleteBook(id);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            return View();
        }
    }
}
