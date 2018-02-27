using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET API/Customers
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>));
        }

        //GET API/Customers/1
        [HttpGet]
        public IHttpActionResult GetCustomers(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }


        //POST API/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomers(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        //PUT API/Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomers(int Id,CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerinDB = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerinDB == null)
                return NotFound();

            Mapper.Map(customerDTO, customerinDB);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE API/Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDB == null)
                return NotFound();

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
            return Ok();
        }
    }
}
