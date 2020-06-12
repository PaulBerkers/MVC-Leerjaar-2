using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CoursesController : Controller
    {
        StudentContext context = new StudentContext();

        // GET: Courses
        public ActionResult Index()
        {
            return View(context.Courses.ToList());
        }
        public ActionResult Details(int? Id)
        {
            Course ctd = context.Courses.Where(c => c.CoursesId == Id).FirstOrDefault();
            return View(ctd);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Course ctd = context.Courses.Where(s => s.CoursesId == Id).FirstOrDefault();
            return View(ctd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course ctd)
        {
            Course course = context.Courses.Where(s => s.CoursesId == ctd.CoursesId).FirstOrDefault();

            course.CoursesName = ctd.CoursesName;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            Course ctd = context.Courses.Where(s => s.CoursesId == Id).FirstOrDefault();
            return View(ctd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            Course ctd = context.Courses.Where(s => s.CoursesId == id).FirstOrDefault();
            context.Courses.Remove(ctd);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}