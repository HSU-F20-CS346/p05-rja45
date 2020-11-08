﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example_RestAPI.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }

        //Specifies that ArtistId inside Albums is an FK to an Artist
        //Also, be sure to mark the collection of FK objects as virtual
        [ForeignKey("ArtistId")]
        public virtual ICollection<Album> Albums { get; set; }
    }
}
