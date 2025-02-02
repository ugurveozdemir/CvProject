using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVproject.Models;
using CVproject.Repositories;

namespace CVproject.Controllers
{
    public class SertificateController : Controller
    {
        GenericRepository<TblSertificates> repo = new GenericRepository<TblSertificates>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        public ActionResult DeleteSertificate(int id)
        {
            var value = repo.TGet(id);
            repo.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSertificate(int id)
        {
            var value = repo.TGet(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSertificate(TblSertificates p)
        {
            TblSertificates t = repo.TGet(p.Id);
            t.Description = p.Description;
            t.Date = p.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult NewSertificate()
        {

            return View();
        
        }
        [HttpPost]
        public ActionResult NewSertificate(TblSertificates p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");

        }
    }
}