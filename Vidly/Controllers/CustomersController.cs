using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

       
        // GET: Customers
        public ActionResult Index()
        {

            //var viewModel = new RandomMovieViewModel {Customers = _context.Customers};
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();


            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            Customer cst = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            if (cst == null)
                return HttpNotFound("No customers with that Id");

            return View(cst);

        }
    }
}