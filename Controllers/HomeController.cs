using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {

        //This is added so we can add stuff to the database from our websites
        private MovieInfoContext dbContext { get; set; }

        //Same as above
        public HomeController(MovieInfoContext someName)
        {
            dbContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyMovies()
        {
            ViewBag.Categories = dbContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MyMovies(MovieDB stuff)
        {
            //These two lines allow us to add stuff to the database
            dbContext.Add(stuff);
            dbContext.SaveChanges();

            return View("Confirmation", stuff);
        }
        [HttpGet]
        public IActionResult MovieList ()
        {
            var applications = dbContext.Movies
                .Include(x => x.Category);

            return View(applications);
        }
    }
}
