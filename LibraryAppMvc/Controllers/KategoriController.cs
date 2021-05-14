using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{

    public class KategoriController : Controller
    {
        MvcLibraryDBEntities entities = new MvcLibraryDBEntities();
        public ActionResult Index()
        {
            var kategoriler = entities.Kategoriler.Where(x=>x.Durum == true).ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler kat)
        {
            kat.Durum = true;
            entities.Kategoriler.Add(kat);
            entities.SaveChanges();
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var silinecekKategori = entities.Kategoriler.Find(id);
            silinecekKategori.Durum = false;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = entities.Kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategoriler kat)
        {
            var kategori = entities.Kategoriler.Find(kat.KategoriID);
            kategori.KategoriAd = kat.KategoriAd;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}