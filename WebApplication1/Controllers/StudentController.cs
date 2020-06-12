using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        StudentContext context = new StudentContext();

        public ActionResult Index()
        {
            return View(context.Students.ToList());
        }

        public ActionResult Details(int? Id)
        {
            Student std = context.Students.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(std);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Student std = context.Students.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Student std)
        {
            Student student = context.Students.Where(s => s.StudentId == std.StudentId).FirstOrDefault();

            student.StudentName = std.StudentName;
            student.Age = std.Age;
            student.EmailAddress = std.EmailAddress;
            student.LoginName = std.LoginName;
            student.Password = std.Password;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            Student std = context.Students.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            Student std = context.Students.Where(s => s.StudentId == id).FirstOrDefault();
            context.Students.Remove(std);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult IndexMoreInfo(int? Id)
        {
            StudentCourseViewModel viewModel = new StudentCourseViewModel();

            //alle studenten uit de context
            viewModel.Students = context.Students;

            //alle curssussen van de gekozen student (Id)
            viewModel.Courses = context.Students.Where(s => s.StudentId == Id).FirstOrDefault().Courses;

            return View(viewModel);
        }
    }
}