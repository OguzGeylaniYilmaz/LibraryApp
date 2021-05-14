using LibraryAppMvc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryAppMvc.Controllers
{
    public class PanelController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();

        [Authorize]
        public ActionResult Index()
        {
            var uyeMail = (string)Session["Mail"];
            //var deger = db.Uyeler.FirstOrDefault(x => x.Mail == uyeMail); 
            var deger = db.Duyurular.ToList();
            var uyeIsim = db.Uyeler.Where(x => x.Mail == uyeMail).Select(y => y.UyeAd + " " + y.UyeSoyad).FirstOrDefault();
            var kulAd = db.Uyeler.Where(x => x.Mail == uyeMail).Select(y => y.KullanıcıAd).FirstOrDefault();
            var okul = db.Uyeler.Where(x => x.Mail == uyeMail).Select(y => y.Okul).FirstOrDefault();
            var foto = db.Uyeler.Where(x => x.Mail == uyeMail).Select(y => y.Fotograf).FirstOrDefault();
            var tel = db.Uyeler.Where(x => x.Mail == uyeMail).Select(y => y.Telefon).FirstOrDefault();
            var uyeId = db.Uyeler.Where(x => x.Mail == uyeMail).Select(y => y.UyeID).FirstOrDefault();
            var toplamKitap = db.Hareketler.Where(x => x.Uye == uyeId).Count();
            var toplamMesaj = db.Mesajlar.Where(x => x.Alici == uyeMail).Count();
            var toplamDuyuru = db.Duyurular.Count();

            ViewBag.v1 = uyeIsim;
            ViewBag.v2 = kulAd;
            ViewBag.v3 = okul;
            ViewBag.v4 = foto;
            ViewBag.v5 = tel;
            ViewBag.v6 = uyeMail;
            ViewBag.v7 = toplamKitap;
            ViewBag.v8 = toplamMesaj;
            ViewBag.v9 = toplamDuyuru;
            return View(deger);
        }
        [HttpPost]
        public ActionResult Index2(Uyeler uyeler)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.Uyeler.FirstOrDefault(x => x.Mail == kullanici);
            uye.UyeAd = uyeler.UyeAd;
            uye.UyeSoyad = uyeler.UyeSoyad;
            uye.KullanıcıAd = uyeler.KullanıcıAd;
            uye.Sifre = uyeler.Sifre;
            uye.Okul = uyeler.Okul;
            uye.Fotograf = uyeler.Fotograf;
            db.SaveChanges();
            return RedirectToAction("Index", "Panel");
        }

        public ActionResult Kitaplar()
        {
            var uyeMail = (string)Session["Mail"];
            var id = db.Uyeler.Where(x => x.Mail == uyeMail.ToString()).Select(y => y.UyeID).FirstOrDefault();
            var kitaplar = db.Hareketler.Where(x => x.Uye == id).ToList();
            return View(kitaplar);
        }

        public ActionResult Duyurular()
        {
            var duyuru = db.Duyurular.ToList();
            return View(duyuru);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }

        public PartialViewResult GetPartial()
        {
            return PartialView();
        }

        public PartialViewResult Ayarlar()
        {
            var kullanici = (string)Session["Mail"];
            var uyeId = db.Uyeler.Where(x => x.Mail == kullanici).Select(y => y.UyeID).FirstOrDefault();
            var uyeBul = db.Uyeler.Find(uyeId);
            return PartialView("Ayarlar",uyeBul);
        }

    }
}