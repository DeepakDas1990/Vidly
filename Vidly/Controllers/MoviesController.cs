using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Lord of The Rings"
            };
            var customers = new List<Customer>
            {
                new Customer { Name="Pravakar Das"},
                new Customer { Name="Bijaya Das"}
            };
            var RandomMovieViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(RandomMovieViewModel);
            
        }
    }
}