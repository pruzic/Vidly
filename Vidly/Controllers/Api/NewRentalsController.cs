using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRenatls(NewRentalDto newRentals)
        {
            //if (newRentals.MovieIds.Count == 0)
            //    return BadRequest("No Movie Ids have been given.");

            //var customer = _context.Customers.SingleOrDefault(c => c.Id == newRentals.CustomerId);
            var customer = _context.Customers.Single(c => c.Id == newRentals.CustomerId);

            //if (customer == null)
            //    return BadRequest("CustomerId is not valid");

            var movies = _context.Movies.Where(m => newRentals.MovieIds.Contains(m.Id)).ToList();

            //if (movies.Count != newRentals.MovieIds.Count)
            //    return BadRequest("One or more Movie Ids are incalid");


            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                movie.NumberAvailable--;
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}