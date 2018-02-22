using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
            //return View(movie);
            //return Content("Hello world is old now. It's time for wass'up bro !!!");
            //return HttpNotFound();
            //return new EmptyResult();
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });
        }

        public ActionResult Edit(int Id)
        {
            return Content("Id =" + Id);
        }

        public ActionResult Index(int? pageIdex, string sortBy)
        {
            if (!pageIdex.HasValue)
                pageIdex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIdex = {0} and sortBy={1}", pageIdex, sortBy));
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}