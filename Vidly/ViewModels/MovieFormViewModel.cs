using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Genre")]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "Please Enter Release Date")]
        [Display(Name = "Release Date")]
        public DateTime? ReleasedDate { get; set; }

        [Required(ErrorMessage = "Please Enter Added Date")]
        [Display(Name = "Added Date")]
        public DateTime? AddedDate { get; set; }

        [Required(ErrorMessage = "Please Enter Number In Stock")]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public Byte? NumberInStock { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleasedDate = movie.ReleasedDate;
            AddedDate = movie.AddedDate;
            NumberInStock = movie.NumberInStock;
        }
    }
    
}