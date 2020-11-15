﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example_RestAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        [ForeignKey("Employee")]
        public int SupportRepID { get; set; }
        public virtual Employee Employee { get; set; }

        //Specifies that ArtistId inside Albums is an FK to an Artist
        //Also, be sure to mark the collection of FK objects as virtual
        [ForeignKey("InvoiceID")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
