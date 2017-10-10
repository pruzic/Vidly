using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        //readonly List<Movie> _movies = new List<Movie>
        //    {
        //        new Movie{ Name = "Shrek!", Id = 1},
        //        new Movie{Name = "Wall-e", Id = 2}
                
        //    };

        // GET: Movies
        //public ActionResult Random()
        //{
        //    var movie = new Movie {Name = "Shrek!"};
        //    return View(movie);
        //}

        //public ActionResult Random()
        //{
            

        //    //ViewData["Movie"] = _movie;

        //    var customers = new List<Customer>
        //    {
        //        new Customer{Name = "Customer 1"},
        //        new Customer{Name = "Customer 2"}
        //    };

        //    var rndViewModel = new RandomMovieViewModel
        //    {
        //        Movies = _movies,
        //        Customers = customers
        //    };

        //    return View(rndViewModel);
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("Id= " + id);
        //}

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
            var movies = _context.Movies.Include(g => g.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int? id)
        {
           Movie mvs = _context.Movies.Include(g => g.Genre).FirstOrDefault(c => c.Id == id);

            if(mvs == null)
                return HttpNotFound("Sorry, we could not find any movie with provided Id: " + id);

            return View(mvs);
        }

       public ActionResult New()
       {
           var genre = _context.Genres.ToList();

           var movieViewModel = new MovieFormViewModel
           {
               Genres = genre
           };

           return View("MovieForm", movieViewModel);
        }


       [HttpPost]
       public ActionResult Save(Movie movie)
       {
           if (movie.Id == 0)
           {
               _context.Movies.Add(movie);
           }
           else
           {
               var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

               movieInDb.Name = movie.Name;
               movieInDb.DateAdded = movie.DateAdded;
               movieInDb.ReleaseDate = movie.ReleaseDate;
               movieInDb.Genre = movie.Genre;
               movieInDb.NumberInStock = movie.NumberInStock;

           }

           _context.SaveChanges();

          return RedirectToAction("Index", "Movies");
       }

        public ActionResult Edit(int id)
        {
            var movieInDb = _context.Movies.Single(m => m.Id == id);
            if (movieInDb == null)
                return HttpNotFound("Movie with Id: " + id + " could not be found!");


            var movieViewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = movieInDb
            };


            return View("MovieForm", movieViewModel);
       }

        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}