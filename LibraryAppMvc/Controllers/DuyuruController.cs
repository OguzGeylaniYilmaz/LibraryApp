using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{
    public class DuyuruController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();
        public ActionResult Index()
        {
            var duyuru = db.Duyurular.ToList();
            return View(duyuru);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(Duyurular dyr)
        {
            db.Duyurular.Add(dyr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var silinecekDuyuru = db.Duyurular.Find(id);
            db.Duyurular.Remove(silinecekDuyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruDetay(Duyurular dyr)
        {
            var duyuru = db.Duyurular.Find(dyr.ID);
            return View("DuyuruDetay", duyuru);
        }

        public ActionResult DuyuruGuncelle(Duyurular dyr)
        {
            var guncellenecekDuyuru = db.Duyurular.Find(dyr.ID);
            guncellenecekDuyuru.Kategori = dyr.Kategori;
            guncellenecekDuyuru.Icerik = dyr.Icerik;
            guncellenecekDuyuru.Tarih = dyr.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}