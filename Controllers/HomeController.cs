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
        private MovieInfoContext DbContext { get; set; }

        //Same as above
        public HomeController(MovieInfoContext someName)
        {
            DbContext = someName;
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
            ViewBag.Categories = DbContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MyMovies(MovieDB stuff)
        {
            if (ModelState.IsValid)
            {
                //These two lines allow us to add stuff to the database
                DbContext.Add(stuff);
                DbContext.SaveChanges();

                return View("Confirmation", stuff);
            }
            else //if invalid
            {
                ViewBag.Categories = DbContext.Categories.ToList();

                return View();
            }
            
        }
        [HttpGet]
        public IActionResult MovieList ()
        {
            var applications = DbContext.Movies
                .Include(x => x.Category)
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = DbContext.Categories.ToList();

            var application = DbContext.Movies.Single(x => x.MovieId == movieid);

            return View("MyMovies", application);
        }

        [HttpPost]
        public IActionResult Edit (MovieDB blah)
        {
            DbContext.Update(blah);
            DbContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var application = DbContext.Movies.Single(x => x.MovieId == movieid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(MovieDB stuff)
        {

            DbContext.Movies.Remove(stuff);
            DbContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
