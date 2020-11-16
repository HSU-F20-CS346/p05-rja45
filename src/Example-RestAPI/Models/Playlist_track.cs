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
        [ForeignKey("Playlist")]
        public int PlaylistID { get; set; }
        public virtual Playlist Playlist { get; set; }

        [ForeignKey("Track")]
        public int TrackID { get; set; }
        public virtual Track Track { get; set; }



    }
}
