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
    public class CustomersController : Controller
    {
        readonly List<Customer> _customers = new List<Customer>
            {
                new Customer{Name = "Predrag Ruzic", Id = 1},
                new Customer{Name = "Stana Ruzic", Id = 2}
            };

        // GET: Customers
        public ActionResult Index()
        {

            var viewModel = new RandomMovieViewModel {Customers = _customers};


            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            Customer cst = _customers.FirstOrDefault(c => c.Id == id) ??
                           new Customer {Name = "Sorry, there is no customer with this " + id + " id"};

            return View(cst);

        }
    }
}