using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVproject.Models;
using CVproject.Repositories;

namespace CVproject.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblLogin> repo = new GenericRepository<TblLogin>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewAdmin()
        {
            return View();
        }

        [HttpPost]

        public ActionResult NewAdmin(TblLogin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveAdmin(int id)
        {
            TblLogin t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            TblLogin t = repo.Find(x => x.Id == id);
            return View("UpdateAdmin", t);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(TblLogin p)
        {
            TblLogin t = repo.Find(x => x.Id == p.Id);
            if (t != null)
            {
                t.username = p.username;
                t.password = p.password;
                repo.TUpdate(t);
            }

            return RedirectToAction("Index");

        }





    }
}