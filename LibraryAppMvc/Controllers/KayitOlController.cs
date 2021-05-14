using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{
    [AllowAnonymous]
    public class KayitOlController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();

        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(Uyeler uye)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.Uyeler.Add(uye);
            db.SaveChanges();
            return View();
        }


    }
}