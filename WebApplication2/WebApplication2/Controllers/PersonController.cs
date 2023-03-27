using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult List()
        {
            int a = 10;
            int b = 20;
            int c = 30;

            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;
            return View();
        }
    }
}