using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var result = repo.List();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(experience experience)
        {
            repo.TAdd(experience);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            experience t = repo.Find(x => x.ID == id);
            repo.TDelete(t);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            experience t = repo.Find(x => x.ID == id);

            return View(t);
        }

        [HttpPost]
        public ActionResult GetExperience(experience p)
        {
            experience t = repo.Find(x => x.ID == p.ID);
            t.title = p.title;
            t.subtitle = p.subtitle;
            t.date = p.date;
            t.description = p.description;

            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}