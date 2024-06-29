using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        GenericRepository<certificate> repo = new GenericRepository<certificate>();
        public ActionResult Index()
        {
            var certificate = repo.List();
            return View(certificate);
        }
        [HttpGet]
        public ActionResult GetCertificate(int id)
        {
            var certificate = repo.Find(x=>x.ID==id);
            ViewBag.d = id;
            return View(certificate);
        }

        [HttpPost]
        public ActionResult GetCertificate(certificate t)
        {
            var certificate = repo.Find(x => x.ID == t.ID);
            certificate.date = t.date;
            certificate.description = t.description;
            repo.TUpdate(certificate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertificate(certificate t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertificate(int id)
        {   
            var cert = repo.Find(x=>x.ID == id);
            repo.TDelete(cert);
            return RedirectToAction("Index");
        }
    }
}