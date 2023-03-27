using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab1Practice.Models;

namespace lab1Practice.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Profile()
        {
            ViewBag.Title = "profile";

            /*ViewBag.Name = "Samin";
            string[] names = new string[3];
            names[0] = "jaman";
            names[1] = "Mollah";
            names[2] = "Mugdho";

            ViewBag.Names = names;
           */
            Product p1 = new Product()
            {
                Name = "pp",
                Id = "pp",
                Price = "11"


            };
            return View(p1);
        }
        public ActionResult ProductList() { 
            List<Product> products = new List<Product>();
            for(int i = 0; i < 10; i++) {
                Product p1 = new Product()
                {
                    Name = "pp" + (i+1),
                    Id = "pp",
                    Price = "11"
                };
            
                products.Add(p1);
            }
          return View(products);
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            return View();
        }
    }
}