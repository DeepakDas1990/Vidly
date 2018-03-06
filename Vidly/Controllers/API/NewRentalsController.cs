using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult CreateNewRentals(NewRentalDTO newRentalDTO)
        {
            var Customer = _context.Customers.Single(m => m.Id == newRentalDTO.CustomerId);

            var movies = _context.Movies.Where(m => newRentalDTO.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest(movie.Name + "Is Not Available");

                movie.NumberAvailable--;

                var NewRental = new Rental
                {
                    Movie = movie,
                    Customer = Customer,
                    DateRented = DateTime.Now,
                };
                _context.Rentals.Add(NewRental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
