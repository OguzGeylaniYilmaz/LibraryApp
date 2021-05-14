using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{
    public class IstatistikController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();
        public ActionResult Index()
        {
            var uye = db.Uyeler.Count();
            ViewBag.toplamUye = uye;
            var kitap = db.Kitaplar.Count();
            ViewBag.toplamKitap = kitap;
            var emanet = db.Kitaplar.Where(x => x.Durum == false).Count();
            ViewBag.emanetKitaplar = emanet;
            var para = db.Cezalar.Sum(x => x.Para);
            ViewBag.toplamPara = para;

            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyaYolu = Path.Combine(Server.MapPath("~/web2/galeri/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyaYolu);
            }
            return RedirectToAction("Galeri");
        }
    }
}