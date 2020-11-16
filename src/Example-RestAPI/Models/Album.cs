using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example_RestAPI.Models
{
    public class Album
    {
        //Primary Key in DB
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }

        //Specifies that ArtistId is a FK for the Artists table

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        //be sure to mark any FK objects as virtual
        public virtual Artist Artist { get; set; }

        [ForeignKey("AlbumID")]
        public virtual ICollection<Track> Tracks { get; set; }

    }
}
