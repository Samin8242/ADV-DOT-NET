﻿using MIM.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIM.Controllers
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
        [HttpGet]
        public ActionResult Register()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student model)
        {
            var db = new ADVDOTNETEntities1();
            db.Students.Add(model);
            db.SaveChanges();

            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var db = new ADVDOTNETEntities1();
            var students = db.Students.ToList();
            return View(students);

        }

        public ActionResult Edit(int id)
        {
            var db = new ADVDOTNETEntities1();
            var st = (from s in db.Students
                      where s.Id == id
                      select s).SingleOrDefault();
            return View(st);
        }
        [HttpPost]
        public ActionResult Edit(Student upstudent)
        {
            var db = new ADVDOTNETEntities1();
            var exst = (from s in db.Students
                        where s.Id == upstudent.Id
                        select s).SingleOrDefault();
            exst.Name = upstudent.Name;
            exst.Profession = upstudent.Profession;
            exst.Gender = upstudent.Gender;
            exst.Dob = upstudent.Dob;

            //db.Entry(exst).CurrentValues.SetValues(upstudent);
            db.SaveChanges();


            //db.Students.Remove(exst);
            return RedirectToAction("List");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}