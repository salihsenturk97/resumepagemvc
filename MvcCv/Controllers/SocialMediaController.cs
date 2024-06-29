using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia

        GenericRepository<socialmedia> repo = new GenericRepository<socialmedia>();
        public ActionResult Index()
        {
            var socialmedia = repo.List();
            return View(socialmedia);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            var socialmedia = repo.List();
            return View(socialmedia);
        }

        [HttpPost]
        public ActionResult AddSocialMedia(socialmedia t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var socialmedia = repo.Find(x => x.ID == id);
            repo.TDelete(socialmedia);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetSocialMedia(int id)
        {
            var socialmedia = repo.Find(x => x.ID == id);
            return View(socialmedia);
        }
        public ActionResult PassiveActiveSocialMedia(socialmedia t)
        {
            var socialmedia = repo.Find(x => x.ID == t.ID);
            if (socialmedia.isActiv == true)
            {
                socialmedia.isActiv = false;
            }
            else
            {
                socialmedia.isActiv = true;
            }

            repo.TUpdate(socialmedia);
            return RedirectToAction("Index");
        }

    }
}