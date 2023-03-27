using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask1.Controllers
{
    public class DashbordController : Controller
    {
        // GET: Dashbord
        public ActionResult MyProfile()
        {
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
    }
}