using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVproject.Models;
using CVproject.Repositories;

namespace CVproject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<TblContact> repo = new GenericRepository<TblContact>();
        public ActionResult Index()
        {
            var values = repo.List();
            
            return View(values);
        }
        public ActionResult DeleteMessage(int id)
        {
            var value = repo.TGet(id);
            repo.TDelete(value);
            return RedirectToAction("Index");

        }
    }
}