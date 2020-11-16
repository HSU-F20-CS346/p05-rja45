using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example_RestAPI.Models
{
    public class Playlist_track
    {
        //Primary Key in DB
        [Key, ForeignKey("Playlist")]
        public int PlaylistID { get; set; }
        [Key, ForeignKey("Track")]
        public string TrackID { get; set; }

        //Specifies that ArtistId is a FK for the Artists table



        //be sure to mark any FK objects as virtual
        public virtual Playlist Playlist { get; set; }
    }
}
