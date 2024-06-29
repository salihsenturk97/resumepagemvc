using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        // GET: Education

        GenericRepository<education> repo = new GenericRepository<education>();
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(education p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            repo.TDelete(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            return View(education);
        }

        [HttpPost]
        public ActionResult UpdateEducation(education e)
        {

            if (!ModelState.IsValid)
            {
                return View("UpdateEducation");
            }
            var education = repo.Find(x => x.ID == e.ID);
            education.title = e.title;
            education.subtitle1 = e.subtitle1;
            education.subtitle2 = e.subtitle2;
            education.date = e.date;
            education.GNO = e.GNO;
            repo.TUpdate(education);
            return RedirectToAction("Index");
        }
    }
}