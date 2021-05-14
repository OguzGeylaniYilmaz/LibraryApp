using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;
namespace LibraryAppMvc.Controllers
{
    public class KitapController : Controller
    {

        MvcLibraryDBEntities entities = new MvcLibraryDBEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from x in entities.Kitaplar select x;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(y => y.KitapAd.Contains(p));
            }
            return View(kitaplar.ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> kategori = (from k in entities.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = k.KategoriAd,
                                                 Value = k.KategoriID.ToString()
                                             }).ToList();

            List<SelectListItem> yazar = (from y in entities.Yazarlar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = y.YazarAd + y.YazarSoyad,
                                              Value = y.YazarID.ToString()
                                          }).ToList();

            ViewBag.ktp = kategori;
            ViewBag.yzr = yazar;

            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(Kitaplar ktp)
        {
            var kitaplar = entities.Kategoriler.Where(x => x.KategoriID == ktp.Kategoriler.KategoriID).FirstOrDefault();
            var yazarlar = entities.Yazarlar.Where(y => y.YazarID == ktp.Yazarlar.YazarID).FirstOrDefault();
            ktp.Kategoriler = kitaplar;
            ktp.Yazarlar = yazarlar;
            entities.Kitaplar.Add(ktp);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = entities.Kitaplar.Find(id);
            entities.Kitaplar.Remove(kitap);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var ktp = entities.Kitaplar.Find(id);

            List<SelectListItem> kategori = (from k in entities.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = k.KategoriAd,
                                                 Value = k.KategoriID.ToString()
                                             }).ToList();

            List<SelectListItem> yazar = (from y in entities.Yazarlar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = y.YazarAd + y.YazarSoyad,
                                              Value = y.YazarID.ToString()
                                          }).ToList();
            ViewBag.ktp = kategori;
            ViewBag.yzr = yazar;

            return View("KitapGetir", ktp);
        }

       public ActionResult KitapGuncelle(Kitaplar k)
        {
            var kitap = entities.Kitaplar.Find(k.KitapID);
            kitap.KitapAd = k.KitapAd;
            kitap.BasımYılı = k.BasımYılı;
            kitap.Sayfa = k.Sayfa;
            kitap.Yayınevi = k.Yayınevi;
            var ktg = entities.Kategoriler.Where(x => x.KategoriID == k.Kategoriler.KategoriID).FirstOrDefault();
            var yzr = entities.Yazarlar.Where(x => x.YazarID == k.Yazarlar.YazarID).FirstOrDefault();
            kitap.Kategori = ktg.KategoriID;
            kitap.Yazar = yzr.YazarID;
            kitap.Durum = true;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}