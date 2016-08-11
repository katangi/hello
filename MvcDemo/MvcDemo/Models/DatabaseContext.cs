using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Data.Entity;
using MvcDemo.Areas.Customer.Models;
using MvcDemo.Areas.Product.Models; 

namespace MvcDemo.Models
{
    public class DatabaseContext:DbContext 
    {
        public DatabaseContext()
            : base()
        {

        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}