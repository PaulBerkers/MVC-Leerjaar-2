using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OnderdeelController : Controller
    {
        StudentContext context = new StudentContext();

        // GET: Onderdeel
        public ActionResult Index()
        {
            return View(context.Onderdelen.ToList());
        }

        public ActionResult Details(int? Id)
        {
            Onderdeel ctd = context.Onderdelen.Where(c => c.OnderdeelId == Id).FirstOrDefault();
            return View(ctd);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Onderdeel onderdeel)
        {
            context.Onderdelen.Add(onderdeel);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Onderdeel ctd = context.Onderdelen.Where(s => s.OnderdeelId == Id).FirstOrDefault();
            return View(ctd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Onderdeel ctd)
        {
            Onderdeel onderdeel = context.Onderdelen.Where(s => s.OnderdeelId == ctd.OnderdeelId).FirstOrDefault();

            onderdeel.OnderdeelName = ctd.OnderdeelName;
            onderdeel.OnderdeelQuantity = ctd.OnderdeelQuantity;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            Onderdeel ctd = context.Onderdelen.Where(s => s.OnderdeelId == Id).FirstOrDefault();
            return View(ctd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            Onderdeel ctd = context.Onderdelen.Where(s => s.OnderdeelId == id).FirstOrDefault();
            context.Onderdelen.Remove(ctd);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}