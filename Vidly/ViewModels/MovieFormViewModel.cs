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
        public IEnumerable<Genre> Genres { get; set; }

        //public Movie Movie { get; set; }

        public int? Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        [Required]
        public DateTime? DateAdded { get; set; }


        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public int? NumberInStock { get; set; }

        [Required]
        public int? GenreId { get; set; }

        public string Title
        {
            get { return Id != 0 ? "Edit Move" : "New Move"; }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }
    }
}