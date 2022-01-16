using HomeworkBtcmp.Data;
using HomeworkBtcmp.Models;
using HomeworkBtcmp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkBtcmp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext _context;

        public HomeController(BookContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                PopularBooks = _context.Books.ToList()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
