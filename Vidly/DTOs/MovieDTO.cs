using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Genre")]
        public byte GenreId { get; set; }

        [Required(ErrorMessage = "Please Enter Release Date")]
        public DateTime ReleasedDate { get; set; }

        [Required(ErrorMessage = "Please Enter Added Date")]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Please Enter Number In Stock")]
        [Range(1, 20)]
        public Byte NumberInStock { get; set; }

    }
}