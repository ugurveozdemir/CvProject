using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVproject.Models;

namespace CVproject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        public PartialViewResult _PartialExperience()
        {
            var values = db.TblExperience.ToList();
            return PartialView(values);
        }

        public PartialViewResult _PartialEducation()
        {
            var values = db.TblEducation.ToList();
            return PartialView(values);
        }

        public PartialViewResult _PartialSkills()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }
        public PartialViewResult _PartialInterests()
        {
            var values = db.TblInterests.ToList();
            return PartialView(values);
        }
        public PartialViewResult _PartialSertificates()
        {
            var values = db.TblSertificates.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult _PartialContact()
        {
            
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _PartialContact(TblContact t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}