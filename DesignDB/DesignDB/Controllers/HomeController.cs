using DesignDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult AddProduct()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            var db = new Task1Entities();
            db.Products.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");

        }
        public ActionResult List()
        {
            var db = new Task1Entities();
            var products = db.Products.ToList();
            return View(products);
        }
        [HttpGet]

        public ActionResult Edit(int id)
        {
            var db = new Task1Entities();
            var pt = (from s in db.Products
                      where s.Id == id
                      select s).SingleOrDefault();
            return View(pt);
        }
        [HttpPost]
        public ActionResult Edit(Product upproduct)
        {
            var db = new Task1Entities();
            var exst = (from s in db.Products
                        where s.Id == upproduct.Id
                        select s).SingleOrDefault();
            exst.Name = upproduct.Name;
            exst.CId = upproduct.CId;
            exst.Price = upproduct.Price;
            exst.Type = upproduct.Type;
            db.SaveChanges();
            return RedirectToAction("List");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            

            var db = new Task1Entities();
            var pt = (from s in db.Products
                      where s.Id == id
                      select s).SingleOrDefault();
            db.Products.Remove(pt);
            db.SaveChanges();
            
            return RedirectToAction("List");
        }

        

    }
}