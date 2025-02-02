using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVproject.Models;
using CVproject.Repositories;
namespace CVproject.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        GenericRepository<TblSkills> repo = new GenericRepository<TblSkills>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewSkill()
        {
            return View();
        }


        [HttpPost]
        public ActionResult NewSkill(TblSkills p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            TblSkills t = repo.TGet(id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            return View(repo.TGet(id));
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkills p)
        {
            TblSkills t = repo.TGet(p.Id);
            t.Skill = p.Skill;
            t.Progress = p.Progress;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }

}