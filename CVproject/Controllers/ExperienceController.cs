using CVproject.Models;
using CVproject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVproject.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddExperience(TblExperience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            TblExperience t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            TblExperience t = repo.Find(x => x.Id == id);
            return View("UpdateExperience", t);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TblExperience p)
        {
            TblExperience t = repo.Find(x => x.Id == p.Id);
            if (t != null)
            {
                t.Title = p.Title;
                t.Subtitle = p.Subtitle;
                t.Description = p.Description;
                t.Date = p.Date;
                repo.TUpdate(t);
            }

            return RedirectToAction("Index");

        }



    }
}