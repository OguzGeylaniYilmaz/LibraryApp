using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{
    public class MesajController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var mesajlar = db.Mesajlar.Where(x=>x.Alici == mail.ToString()).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar msj)
        {
            var uyeMail = (string)Session["Mail"];
            msj.Gonderen = uyeMail.ToString();
            msj.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.Mesajlar.Add(msj);
            db.SaveChanges();
            return View();
        }
        public ActionResult GidenMesaj()
        {
            var mail = (string)Session["Mail"];
            var mesajlar = db.Mesajlar.Where(x => x.Gonderen == mail.ToString()).ToList();
            return View(mesajlar);
        }

        public PartialViewResult PartialMesaj()
        {
            return PartialView();
        }

        public PartialViewResult MesajSayilari()
        {
            var mail = (string)Session["Mail"];
            var gelenMesaj = db.Mesajlar.Where(x => x.Alici == mail).Count();
            var gidenMesaj = db.Mesajlar.Where(x => x.Gonderen == mail).Count();

            ViewBag.v1 = gelenMesaj;
            ViewBag.v2 = gidenMesaj;

            return PartialView();
        }

    }
}