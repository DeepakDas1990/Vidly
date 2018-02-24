using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _Context;
        public CustomersController()
        {
            _Context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();    
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _Context.Customers.ToList();
            return View(customers);
        }

        // GET: Customers/Details/1
        public ActionResult Details(int Id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}