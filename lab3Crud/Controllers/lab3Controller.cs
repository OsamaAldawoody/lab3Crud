using lab3Crud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3Crud.Controllers
{
    public class lab3Controller : Controller
    {
        // GET: lab3
        ITI db = new ITI(); 
        public ActionResult Index()
        {
            List<Instructor> ins = db.Instructors.ToList();
            return View(ins);
        }
        public ActionResult details(int id)
        {
            Instructor s = db.Instructors.Where(n => n.Ins_Id == id).FirstOrDefault();
            return View(s);
        }

        public ActionResult edit(int id)
        {
            
            List<Department> dp = db.Departments.ToList();
            SelectList li = new SelectList(dp, "Dept_Id","Dept_Name");
            ViewBag.li = li;
            Instructor ss = db.Instructors.Where(s => s.Ins_Id == id).FirstOrDefault();
            return View(ss);
        }
        [HttpPost]
        public ActionResult edit(Instructor ins)
        {
            db.Entry(ins).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        
        
        public ActionResult create()
        {
            List<Department> dp = db.Departments.ToList();
            SelectList li = new SelectList(dp, "Dept_Id", "Dept_Name");
            ViewBag.li = li;

            return View();
        }
        [HttpPost]
        public ActionResult create(Instructor ins)
        {
            db.Instructors.Add(ins);
            db.SaveChanges();

            List<Instructor> sts = db.Instructors.Include(n => n.Department).ToList();
            return View("Index", sts);

        }

        public ActionResult delete(int id)
        {
            Instructor s = db.Instructors.Where(n => n.Ins_Id == id).FirstOrDefault();

            db.Instructors.Remove(s);
            db.SaveChanges();


            return RedirectToAction("index");
        }

    }

}