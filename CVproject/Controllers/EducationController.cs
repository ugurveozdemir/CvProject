using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVproject.Models;
using CVproject.Repositories;

namespace CVproject.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<TblEducation> repo = new GenericRepository<TblEducation>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducation p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            TblEducation e = repo.TGet(id);
            repo.TDelete(e);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = repo.TGet(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducation p)
        {
            TblEducation t = repo.TGet(p.Id);
            if (t != null)
            {
                t.Title = p.Title;
                t.Subtitle = p.Subtitle;
                t.Subtitle2 = p.Subtitle2;
                t.GPA = p.GPA;
                t.Date = p.Date;
                repo.TUpdate(t);

            }
            return RedirectToAction("Index");
        }
    }
}