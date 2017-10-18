﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
       public IHttpActionResult GetCustomers(string query = null)
       {

           var customersQuery = _context.Customers
               .Include(m => m.MembershipType);

           if (!string.IsNullOrWhiteSpace(query))
               customersQuery = customersQuery.Where(c => c.Name.Contains(query));

           var customerDtos = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);

           //return Ok(_context.Customers
           //    .Include(m => m.MembershipType)
           //    .ToList()
           //    .Select(Mapper.Map<Customer, CustomerDto>));

           return Ok(customerDtos);
       }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound(); //throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }

        //POST /api/customers

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(); 

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerFromDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerFromDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            Mapper.Map(customerDto, customerFromDb);
            
            _context.SaveChanges();
            
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer ==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customer);
            _context.SaveChanges();

        }

    }
}
