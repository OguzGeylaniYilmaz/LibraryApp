using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{
    public class YazarController : Controller
    {
        MvcLibraryDBEntities entities = new MvcLibraryDBEntities();
        public ActionResult Index()
        {
            var yazarlar = entities.Yazarlar.ToList();
            return View(yazarlar);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(Yazarlar yzr)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            entities.Yazarlar.Add(yzr);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil(int id)
        {
            var silinecekYazar = entities.Yazarlar.Find(id);
            entities.Yazarlar.Remove(silinecekYazar);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yazar = entities.Yazarlar.Find(id);
            return View("YazarGetir", yazar);
        }

        public ActionResult YazarGuncelle(Yazarlar yzr)
        {
            var yazar = entities.Yazarlar.Find(yzr.YazarID);
            yazar.YazarAd = yzr.YazarAd;
            yazar.YazarSoyad = yzr.YazarSoyad;
            yazar.Detay = yzr.Detay;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarKitapları(int id)
        {
            var yazarKitap = entities.Kitaplar.Where(x => x.Yazar == id).ToList();
            var yazarAd = entities.Yazarlar.Where(x => x.YazarID == id).Select(y => y.YazarAd + " " + y.YazarSoyad).FirstOrDefault();
            ViewBag.yzrAd = yazarAd;
            return View(yazarKitap);
        }
    }
}