﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class MovieActor
    {
        [Key]
        public int ID { get; set; }

        public Movie MovieID { get; set; }

        public Actor ActorID { get; set; }
    }
}