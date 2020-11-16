using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example_RestAPI.Models
{
    public class Track
    {
        //Primary Key in DB
        [Key]
        public int TrackID { get; set; }
        public string Name { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        //Specifies that AlbumId is a FK for the Albums table
        [ForeignKey("Genre")]
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }

        [ForeignKey("Album")]
        public int AlbumID { get; set; } 
        public virtual Album Album { get; set; }
        
        [ForeignKey("Media_Type")]
        public int MediaTypeID { get; set; }
        public virtual Media_type Media_type { get; set; }

        [ForeignKey("TrackID")]
        public virtual ICollection<Invoice_item> Invoice_Items { get; set; }


    }
}
