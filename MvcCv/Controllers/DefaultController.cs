using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        resumeEntities db = new resumeEntities();
            public ActionResult Index()
        {
            var about = db.about.ToList();
            return View(about);
        }

        public PartialViewResult SocialMedia()
        {
            var socialmedias = db.socialmedia.Where(x=>x.isActiv==true).ToList();
            return PartialView(socialmedias);
        }

        public PartialViewResult Experience()
        {
            var experience = db.experience.ToList();
            return PartialView(experience);
        }

        public PartialViewResult Education()
        {
            var educations = db.education.ToList();
            return PartialView(educations);
        }

        public PartialViewResult Skill()
        {
            var skills = db.skill.ToList();
            return PartialView(skills);
        }

        public PartialViewResult Hobby()
        {
            var hobbies = db.hobby.ToList();
            return PartialView(hobbies);
        }

        public PartialViewResult Certificate()
        {
            var certificates = db.certificate.ToList();
            return PartialView(certificates);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            var contacts = db.contact.ToList();
            return PartialView(contacts);
        }
        [HttpPost]
        public PartialViewResult Contact(contact contact)
        {
            contact.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.contact.Add(contact);
            db.SaveChanges();
            return PartialView();
        }
    }
}