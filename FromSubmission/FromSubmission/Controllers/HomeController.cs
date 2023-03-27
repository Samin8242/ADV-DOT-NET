using FromSubmission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FromSubmission.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        public ActionResult Index(Login l)
        {

            return View(l);
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
    }
}