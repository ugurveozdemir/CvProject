using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVproject.Models;
using CVproject.Repositories;


namespace CVproject.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest
        GenericRepository<TblInterests> repo = new GenericRepository<TblInterests>();

        [HttpGet]
        public ActionResult Index()
        {

            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(TblInterests p)
        {
           TblInterests t = repo.Find(x=> x.Id == 1);
            t.Interest1 = p.Interest1;
            t.Interest2 = p.Interest2;
    
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}