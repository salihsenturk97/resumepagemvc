using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        GenericRepository<admin> repo = new GenericRepository<admin>();
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }

        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(admin admin)
        {
            repo.TAdd(admin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            admin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            admin t = repo.Find(x => x.ID == id);

            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(admin p)
        {
            admin t = repo.Find(x => x.ID == p.ID);
            t.username = p.username;
            t.password = p.password;

            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}