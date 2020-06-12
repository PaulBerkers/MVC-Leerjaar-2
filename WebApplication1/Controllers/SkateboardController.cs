using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class SkateboardController : Controller
    {
        StudentContext context = new StudentContext();

        // GET: Skateboard
        public ActionResult Index()
        {
            return View(context.Skateboards.ToList());
        }
        public ActionResult Details(int? Id)
        {
            Skateboard std = context.Skateboards.Where(s => s.SkateboardId == Id).FirstOrDefault();
            return View(std);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Skateboard skateboard)
        {
            context.Skateboards.Add(skateboard);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Skateboard std = context.Skateboards.Where(s => s.SkateboardId == Id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Skateboard skateboards)
        {
            Skateboard skateboard = context.Skateboards.Where(s => s.SkateboardId == skateboards.SkateboardId).FirstOrDefault();

            skateboard.SkateboardBrand = skateboards.SkateboardBrand;
            skateboard.SkateboardCurve = skateboards.SkateboardCurve;
            skateboard.SkateboardWidth = skateboards.SkateboardWidth;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            Skateboard std = context.Skateboards.Where(s => s.SkateboardId == Id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            Skateboard std = context.Skateboards.Where(s => s.SkateboardId == id).FirstOrDefault();
            context.Skateboards.Remove(std);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult IndexMoreInfo(int? Id)
        {
            SkateboardOnderdeelViewModel viewModel = new SkateboardOnderdeelViewModel();

            //alle studenten uit de context
            viewModel.Skateboards = context.Skateboards;

            //alle curssussen van de gekozen student (Id)
            viewModel.Onderdelen = context.Skateboards.Where(s => s.SkateboardId == Id).FirstOrDefault().Onderdelen;

            return View(viewModel);
        }
    }
}