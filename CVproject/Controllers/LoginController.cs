using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CVproject.Models;
using CVproject.Repositories;

namespace CVproject.Controllers
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
        public ActionResult Index(TblLogin p)
        {
            DbCvEntities db = new DbCvEntities();
            var userinfo  = db.TblLogin.FirstOrDefault(x=> x.username == p.username && x.password == p.password);
            if (userinfo != null) 
            {
                FormsAuthentication.SetAuthCookie(userinfo.username, false);
                Session["username"] = userinfo.username.ToString();
                return RedirectToAction("Index","About"); 
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
            return RedirectToAction("Index", "Login");
        }
    }
}