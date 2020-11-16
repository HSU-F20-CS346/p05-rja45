using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example_RestAPI.Models
{
    public class Media_type
    {
        [Key]
        public int MediaTypeID { get; set; }

        public string Name { get; set; }

        //Specifies that ArtistId inside Albums is an FK to an Artist
        //Also, be sure to mark the collection of FK objects as virtual
        [ForeignKey("MediaTypeID")]
        public virtual ICollection<Track> Tracks { get; set; }
    }
}