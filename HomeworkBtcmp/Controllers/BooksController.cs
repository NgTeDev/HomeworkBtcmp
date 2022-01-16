using HomeworkBtcmp.Data;
using HomeworkBtcmp.Entity;
using HomeworkBtcmp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkBtcmp.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookContext _context;
        public BooksController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List(int? id, string q)
        {
            var books = _context.Books.AsQueryable();

            if (id != null)
            {
                books = books
                    .Include(m => m.Genres)
                    .Where(m => m.Genres.Any(g => g.GenreId == id));
            }

            if (!string.IsNullOrEmpty(q))
            {
                books = books.Where(i =>
                    i.Title.ToLower().Contains(q.ToLower()) ||
                    i.Description.ToLower().Contains(q.ToLower()));
            }

            var model = new BooksViewModel()
            {
                Books = books.ToList()
            };

            return View("Books", model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_context.Books.Find(id));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book m)
        {
            _context.Books.Add(m);
            _context.SaveChanges();
            TempData["Message"] = $"{m.Title} isimli kitap eklendi";
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(_context.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book m)
        {
            _context.Books.Update(m);
            _context.SaveChanges();
            return RedirectToAction("List", "Books", new { @id = m.BookId });
        }

        [HttpPost]
        public IActionResult Delete(int BookId, string Title)
        {
            var entity = _context.Books.Find(BookId);
            _context.Books.Remove(entity);
            _context.SaveChanges();
            TempData["Message"] = $"{Title} isimli kitap silindi";
            return RedirectToAction("List");
        }
    }
}
