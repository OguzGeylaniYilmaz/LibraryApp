using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;
using LibraryAppMvc.Models.Classes;

namespace LibraryAppMvc.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();
        [HttpGet]
        public ActionResult Index()
        {
            FirstClass first = new FirstClass();
            first.Deger1 = db.Kitaplar.ToList();
            first.Deger2 = db.Hakkimizda.ToList();

            return View(first);
        }

        [HttpPost]
        public ActionResult Index(Iletisim ıletisim)
        {
            db.Iletisim.Add(ıletisim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}