using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = _Context.MembershipTypes.ToList()
            };
            return View(viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _Context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        // GET: Customers/Details/1
        public ActionResult Details(int Id)
        {
            var customer = _Context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}