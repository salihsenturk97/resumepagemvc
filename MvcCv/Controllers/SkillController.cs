using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        readonly GenericRepository<skill> repo = new GenericRepository<skill>();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(skill p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var skills = repo.Find(x => x.ID == id);
            repo.TDelete(skills);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var skills = repo.Find(x => x.ID == id);

            return View(skills);
        }

        [HttpPost]
        public ActionResult UpdateSkill(skill p)
        {
            skill t = repo.Find(x => x.ID == p.ID);
            t.skill1 = p.skill1;
            t.ratio = p.ratio;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}