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
    public class LoginController : Controller
    {
        //
        // GET: /Customer/Customer/
        DatabaseContext ObjDatabase = new DatabaseContext();

        [HttpPost]
        public ActionResult Index(Models.Customer username)
        {
            string name = username.Name;
            int id = username.Id;
            var result = (from e in ObjDatabase.Customers
                          where e.Name == name && e.Id==id
                          select e).FirstOrDefault();

            //var user =Convert.ToString(ObjDatabase.Customers.FirstOrDefault(u => u.Name ==Convert.ToString(username)));

            if (result != null)
            {
                return View("Main",result);
                //return RedirectToAction("MyCustomer", "Customer", new { area = "Customer" });
            }
            else
            {
                MessageBox.Show("Enter wrong password");
               // return RedirectToAction("Main");
                // TODO: Increase user-login failure count and system-wide failure count
            }
           return View();
           
        }
        public ActionResult Index()
        {
            
            return View();

        }
        public ActionResult Main()
        {

            return View();

        }
    }
}
