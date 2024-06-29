using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(admin p)
        {
            resumeEntities db = new resumeEntities();
           var user = db.admin.FirstOrDefault(x => x.username == p.username && x.password == p.password);

            if (user != null) {
                FormsAuthentication.SetAuthCookie(user.username,false);
                Session["username"] = user.username.ToString();
                return RedirectToAction("Index", "About");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}