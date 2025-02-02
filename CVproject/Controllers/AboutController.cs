using CVproject.Models;
using CVproject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVproject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();

        [HttpGet]
        public ActionResult Index()
        {

            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            TblAbout t = repo.Find(x => x.Id == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.Phone = p.Phone;
            t.Mail = p.Mail;
            t.Description = p.Description;
            t.Image = p.Image;


            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}