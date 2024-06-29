using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        // GET: About


        GenericRepository<about> repo = new GenericRepository<about>();

        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(about p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.name = p.name;
            t.surname = p.surname;
            t.email = p.email;
            t.phone = p.phone;
            t.description = p.description;
            t.address = p.address;
            t.profilephoto = p.profilephoto;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}