using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example_RestAPI.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
      
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public decimal Total { get; set; }


        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customers { get; set; }

        //Specifies that ArtistId inside Albums is an FK to an Artist
        //Also, be sure to mark the collection of FK objects as virtual
        [ForeignKey("InvoiceID")]
        public virtual ICollection<Invoice_item> Invoice_items { get; set; }
    }
}
