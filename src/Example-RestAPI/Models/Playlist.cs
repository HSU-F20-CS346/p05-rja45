using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example_RestAPI.Models
{
    public class Playlist
    {
        //Primary Key in DB
        [Key]
        public int PlaylistID { get; set; }
        public string Name { get; set; }

        //Specifies that ArtistId is a FK for the Artists table

        [ForeignKey("PlaylistID")]

        //be sure to mark any FK objects as virtual
        public virtual Playlist_track Playlist_track { get; set; }
    }
}