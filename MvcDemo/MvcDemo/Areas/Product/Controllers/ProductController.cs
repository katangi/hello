using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;
namespace MvcDemo.Areas.Product.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/Product/
        DatabaseContext ObjDatabase = new DatabaseContext();

        [HttpPost]
        public ActionResult MyProduct(MvcDemo.Areas.Product.Models.Product objcust)
        {
            MvcDemo.Areas.Product.Models.Product objcust1 = new MvcDemo.Areas.Product.Models.Product()
            {

                Name = objcust.Name,
                Description = objcust.Description,
                price=objcust.price
         
            };

            ObjDatabase.Products.Add(objcust1);
            ObjDatabase.SaveChanges();
            TempData["Success"] = "Records has been added successfully";
            return RedirectToAction("Index");
        }
        public ActionResult MyProduct()
        {
            MvcDemo.Areas.Product.Models.Product objcust1 = new MvcDemo.Areas.Product.Models.Product();
            return PartialView("AddView", objcust1);
        }
        public ActionResult Index()
        {
            List<MvcDemo.Areas.Product.Models.Product> productList = ObjDatabase.Products.ToList();
            return View(productList);
        }

    }
}
