using CinemaTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cinemas's logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string Logo { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Cinema name is required")]

        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema description is required")]

        public string Description { get; set; }

        //aici am adaugat legatura tabelului cinema cu tabelul movie
        public List<Movie> Movies { get; set; } //un cinema poate avea mai multe filme
    }
}