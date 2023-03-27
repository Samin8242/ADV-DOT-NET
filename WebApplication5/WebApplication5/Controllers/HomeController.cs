using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
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
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register()
        {
            var db = new ADVDOTNETEntities(Customer model);
            db.Students.Add(model);
            db.SaveChanges();

            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var db = new ADVDOTNETEntities();
            var students = db.Students.ToList();
            return View(students);

        }

        public ActionResult Edit(int id)
        {
            var db = new ADVDOTNETEntities();
            var st = (from s in db.Customer
                      where s.Id == id
                      select s).SingleOrDefault();
            return View(st);
        }
        [HttpPost]
        public ActionResult Edit()
        {
            var db = new ADVDOTNETEntities();
            var exst = (from s in db.Customer
                        where s.Id == upCustomer.Id
                        select s).SingleOrDefault();
            exst.Name = upCustomer.Name;
            exst.Profession = upcustomer.Profession;
            exst.Gender = upcustomer.Gender;
            exst.Dob = upcustomer.Dob;

            //db.Entry(exst).CurrentValues.SetValues(upstudent);
            db.SaveChanges();


            //db.Students.Remove(exst);
            return RedirectToAction("List");
        }
    }
}