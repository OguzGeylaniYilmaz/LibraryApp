using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{
    public class PersonelController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();
        public ActionResult Index()
        {
            var personeller = db.Personeller.ToList();
            return View(personeller);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personeller per)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.Personeller.Add(per);
            db.SaveChanges();
            return View();
        }

        public ActionResult PersonelSil(int id)
        {
            var silinecekPersonel = db.Personeller.Find(id);
            db.Personeller.Remove(silinecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = db.Personeller.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(Personeller per)
        {
            var personel = db.Personeller.Find(per.PersonelID);
            personel.PersonelAd = per.PersonelAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}