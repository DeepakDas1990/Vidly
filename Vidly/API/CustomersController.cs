using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //GET API/Customers/1
        [HttpGet]
        public Customer GetCustomers(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }


        //POST API/Customers
        [HttpPost]
        public void CreateCustomers(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        //PUT API/Customers/1
        [HttpPut]
        public void UpdateCustomers(int Id,Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerinDB = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerinDB.Name = customer.Name;
            customerinDB.BirthDate = customer.BirthDate;
            customerinDB.MembershipTypeId = customer.MembershipTypeId;
            customerinDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
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
