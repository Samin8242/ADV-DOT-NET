using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab1Practice.Controllers
{
    public class pagesController : Controller
    {
        // GET: pages
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginSubmit()
        {
            /////some condition
            //redirection
            TempData["Msg"] = "Login Successfull";
            return RedirectToAction("Index", "Dashboard");
            //return Redirect("https://www.aiub.edu");

        }
    }
}