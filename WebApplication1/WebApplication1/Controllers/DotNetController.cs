using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DotNetController : Controller
    {
        // GET: DotNet
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Education()
        {
            return View();
        }
        public ActionResult Project()
        {
            return View();
        }
        public ActionResult Referance()
        {
            return View();
        }
    }
}