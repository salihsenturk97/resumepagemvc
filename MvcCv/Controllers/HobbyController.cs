using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobbyController : Controller
    {
        // GET: Hobby
        readonly GenericRepository<hobby> repo = new GenericRepository<hobby>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobby = repo.List();
            return View(hobby);
        }
        [HttpPost]
        public ActionResult Index(hobby p)
        {
           var t = repo.Find(x=>x.ID == 1);
            t.description1 = p.description1;
            t.description2 = p.description2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}