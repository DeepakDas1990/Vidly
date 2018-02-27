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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        //GET API/Customers/1
        [HttpGet]
        public CustomerDTO GetCustomers(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDTO>(customer);
        }


        //POST API/Customers
        [HttpPost]
        public CustomerDTO CreateCustomers(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;
            return customerDTO;
        }

        //PUT API/Customers/1
        [HttpPut]
        public void UpdateCustomers(int Id,CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerinDB = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDTO, customerinDB);
            
            _context.SaveChanges();
        }

        //DELETE API/Customers/1
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}
