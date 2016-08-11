using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
//using System.Web;

namespace MvcDemo.Areas.Customer.Models
{
    public class Customer
    {
        
        public int Id { get; set; }

        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter PhoneNo")]
        [RegularExpression("([0-9]+)", ErrorMessage="Please inter Numeric value")] 
        [Display(Name = "PhoneNo")]
        public string  PhoneNo { get; set; }

        //public List <Customer> Customers { get; set; }
    }
}