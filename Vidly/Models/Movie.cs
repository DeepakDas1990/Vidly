using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please Enter Genre")]
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }

        [Required(ErrorMessage = "Please Enter Release Date")]
        [Display(Name = "Release Date")]
        public DateTime ReleasedDate { get; set; }

        [Required(ErrorMessage = "Please Enter Added Date")]
        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Please Enter Number In Stock")]
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public Byte NumberInStock { get; set; }
    }
}