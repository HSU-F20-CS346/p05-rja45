using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example_RestAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        [ForeignKey("EmployeeID")]
        public int? ReportsTo { get; set; }
       

        //Specifies that ArtistId inside Albums is an FK to an Artist
        //Also, be sure to mark the collection of FK objects as virtual
        [ForeignKey("InvoiceID")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
