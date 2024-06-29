using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        readonly GenericRepository<contact> repo = new GenericRepository<contact>();
        public ActionResult Index()
        {
            var contact = repo.List();
            return View(contact);
        }
    }
}