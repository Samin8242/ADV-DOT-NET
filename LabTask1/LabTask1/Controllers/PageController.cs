using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask1.Controllers
{
    public class PageController : Controller
    {
        // GET: Home
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
            TempData["Msg"] = "Login Successfull";
            return RedirectToAction("Index", "Dashboard");
            return View();
        }
    }
}