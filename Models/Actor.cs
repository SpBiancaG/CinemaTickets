﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL{ get; set; }
        public string FullName { get; set;}
        public string Bio { get; set;}
        
        //relatii intre tabele
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}
