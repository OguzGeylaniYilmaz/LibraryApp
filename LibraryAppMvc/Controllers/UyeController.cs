using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;
using PagedList;

namespace LibraryAppMvc.Controllers
{
    public class UyeController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();
        public ActionResult Index(int page = 1)
        {
            var uyeler = db.Uyeler.ToList().ToPagedList(page, 3);
            return View(uyeler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(Uyeler uye)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.Uyeler.Add(uye);
            db.SaveChanges();
            return View();
        }

        public ActionResult UyeSil(int id)
        {
            var silinecekUye = db.Uyeler.Find(id);
            db.Uyeler.Remove(silinecekUye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.Uyeler.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(Uyeler uye)
        {
            var uyeler = db.Uyeler.Find(uye.UyeID);
            uye.UyeAd = uye.UyeAd;
            uye.UyeSoyad = uye.UyeSoyad;
            uye.Mail = uye.Mail;
            uye.KullanıcıAd = uye.KullanıcıAd;
            uye.Sifre = uye.Sifre;
            uye.Okul = uye.Okul;
            uye.Telefon = uye.Telefon;
            uye.Fotograf = uye.Fotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeKitapGecmisi(int id)
        {
            var kitapGecmisi = db.Hareketler.Where(x => x.Uye == id);
            return View(kitapGecmisi.ToList());
        }
    }
}