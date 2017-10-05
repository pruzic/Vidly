using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //private readonly ApplicationDbContext _moviesFromDb;

        //public MoviesController()
        //{
        //    _moviesFromDb = new ApplicationDbContext();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    _moviesFromDb.Dispose();
        //}



        readonly List<Movie> _movies = new List<Movie>
            {
                new Movie{ Name = "Shrek!", Id = 1},
                new Movie{Name = "Wall-e", Id = 2}
                
            };

        // GET: Movies
        //public ActionResult Random()
        //{
        //    var movie = new Movie {Name = "Shrek!"};
        //    return View(movie);
        //}

        public ActionResult Random()
        {
            

            //ViewData["Movie"] = _movie;

            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            var rndViewModel = new RandomMovieViewModel
            {
                Movies = _movies,
                Customers = customers
            };

            return View(rndViewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id= " + id);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{

        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(string.Format("pageIndex={0}, sortBy={1}", pageIndex, sortBy));
        //}


        public ActionResult Index()
        {
            var movies = new ViewModels.RandomMovieViewModel {Movies = _movies};

            return View(movies);
        }

        public ActionResult Details(int? id)
        {
            Movie mvs = _movies.FirstOrDefault(c => c.Id == id) ??
                           new Movie { Name = "Sorry, there is no movie with this " + id + " id" };

            return View(mvs);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}