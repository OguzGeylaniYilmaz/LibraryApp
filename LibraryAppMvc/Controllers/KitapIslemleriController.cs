using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{
    [Authorize(Roles = "A")]
    public class KitapIslemleriController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();


        public ActionResult Index()
        {
            var islemler = db.Hareketler.Where(x => x.IslemDurum == false).ToList();
            return View(islemler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> uye = (from x in db.Uyeler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.UyeAd + " " + x.UyeSoyad,
                                            Value = x.UyeID.ToString()
                                        }).ToList();

            List<SelectListItem> kitap = (from y in db.Kitaplar.Where(p => p.Durum == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = y.KitapAd,
                                              Value = y.KitapID.ToString()
                                          }).ToList();


            List<SelectListItem> personel = (from z in db.Personeller.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = z.PersonelAd,
                                                 Value = z.PersonelID.ToString()
                                             }).ToList();
            ViewBag.uyeler = uye;
            ViewBag.kitaplar = kitap;
            ViewBag.personeller = personel;
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(Hareketler hareket)
        {
            var uyeDeger = db.Uyeler.Where(x => x.UyeID == hareket.Uyeler.UyeID).FirstOrDefault();
            var kitapDeger = db.Kitaplar.Where(x => x.KitapID == hareket.Kitaplar.KitapID).FirstOrDefault();
            var personelDeger = db.Personeller.Where(x => x.PersonelID == hareket.Personeller.PersonelID).FirstOrDefault();

            hareket.Uyeler = uyeDeger;
            hareket.Kitaplar = kitapDeger;
            hareket.Personeller = personelDeger;

            db.Hareketler.Add(hareket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IadeEt(Hareketler hareket)
        {
            var iade = db.Hareketler.Find(hareket.ID);
            DateTime t1 = DateTime.Parse(iade.IadeTarih.ToString());
            DateTime t2 = DateTime.Parse(DateTime.Now.ToShortDateString());
            TimeSpan t3 = t2 - t1;
            ViewBag.trh = t3.TotalDays;
            return View("IadeEt", iade);
        }

        public ActionResult IadeGuncelle(Hareketler hareket)
        {
            var hrkt = db.Hareketler.Find(hareket.ID);
            hrkt.UyeIadeTarih = hareket.UyeIadeTarih;
            hrkt.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}