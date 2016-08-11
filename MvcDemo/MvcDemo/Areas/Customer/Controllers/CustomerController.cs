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
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/Customer/
        DatabaseContext ObjDatabase = new DatabaseContext();

        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            var customer = from cut in ObjDatabase.Customers select cut;
            try
            {
                if (Search_Data != null)
                {
                    Page_No = 1;
                }
                else
                {
                    Search_Data = Filter_Value;
                }

                ViewBag.FilterValue = Search_Data;
 
                if (!String.IsNullOrEmpty(Search_Data))
                {
                    {
                        customer = customer.Where(cut => cut.Name.ToUpper().Contains(Search_Data.ToUpper()));

                    }
                }


                switch (Sorting_Order)
                {
                    case "Name_Description":
                        
                        customer = customer.OrderByDescending(cut => cut.Name);
                        break;
                    //case "Phone_No":
                    //    customer = customer.OrderBy(cut => cut.PhoneNo);
                    //    break;
                    //case "Address_Description":
                    //    customer = customer.OrderByDescending(cut => cut.Address);
                    //    break;
                    default:
                        customer = customer.OrderBy(cut => cut.Name);
                        break;
                }
                // List<MvcDemo.Areas.Customer.Models.Customer> customerList = ObjDatabase.Customers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
           
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(customer.ToPagedList(No_Of_Page, Size_Of_Page));
        }
        public ActionResult MyCustomer()
        {
            MvcDemo.Areas.Customer.Models.Customer objcust1 = new MvcDemo.Areas.Customer.Models.Customer();
            return View("AddView", objcust1);
        }

        [HttpPost]
        public ActionResult MyCustomer(MvcDemo.Areas.Customer.Models.Customer objcust)
        {

            if (objcust.Id > 0)
            {
                try
                {
                    MvcDemo.Areas.Customer.Models.Customer objcust1 = ObjDatabase.Customers.Single(s => s.Id == objcust.Id);
                    objcust1.Name = objcust.Name;
                    objcust1.PhoneNo = objcust.PhoneNo;
                    objcust1.Address = objcust.Address;
                    ObjDatabase.SaveChanges();
                    TempData["Success"] = "Records has been Updated successfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                try
                {

                    MvcDemo.Areas.Customer.Models.Customer objcust1 = new MvcDemo.Areas.Customer.Models.Customer()
                    {

                        Name = objcust.Name,
                        Address = objcust.Address,
                        PhoneNo = objcust.PhoneNo

                    };

                    ObjDatabase.Customers.Add(objcust1);
                    ObjDatabase.SaveChanges();
                    TempData["Success"] = "Records has been added successfully";


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            MvcDemo.Areas.Customer.Models.Customer cust = ObjDatabase.Customers.FirstOrDefault(s => s.Id == id);

            return View("AddView", cust);
        }


        public ActionResult Delete(int id)
        {
            MvcDemo.Areas.Customer.Models.Customer cust = ObjDatabase.Customers.FirstOrDefault(s => s.Id == id);
            ObjDatabase.Customers.Remove(cust);
            ObjDatabase.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
