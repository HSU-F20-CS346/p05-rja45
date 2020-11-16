using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example_RestAPI.Models
{
    public class Invoice_item
    {
        //Primary Key in DB
        [Key]
        public int InvoiceLineID { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }


        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        //Specifies that AlbumId is a FK for the Albums table
        [ForeignKey("Track")]
        public int TrackID { get; set; }

        public virtual Track Track { get; set; }




 

    }
}
