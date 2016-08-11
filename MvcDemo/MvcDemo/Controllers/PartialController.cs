using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using MvcDemo.Areas.Customer;
using System.Data.Entity.Validation;
using System.Diagnostics;
using PagedList;
using PagedList.Mvc;

namespace MvcDemo.Areas.Customer.Controllers
{
    public class PartialController : Controller
    {
        //
        // GET: /Customer/Customer/
        DatabaseContext ObjDatabase = new DatabaseContext();

       
        public ActionResult Index()
        {

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(new Partial() { partialModel = Sampledetails() });
        }
        private List<Partial> Sampledetails()
        {
            List<Partial> model = new List<Partial>();

            model.Add(new Partial()
            {

                Name = "Rima",
                Age = 20,
                Address = "Kannur"
            });

            model.Add(new Partial()
            {

                Name = "Rohan",
                Age = 23,
                Address = "Ernakulam"
            });
            model.Add(new Partial()
            {
                Name = "Reshma",
                Age = 22,
                Address = "Kannur"
            });

            return model;
        }

    }
}
