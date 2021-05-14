using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{
    public class AyarlarController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();
        public ActionResult Index()
        {
            var kullanici = db.Admin.ToList();
            return View(kullanici);
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(Admin admin)
        {
            db.Admin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            var adminId = db.Admin.Find(id);
            db.Admin.Remove(adminId);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AdminGetir(int id)
        {
            var ID = db.Admin.Find(id);
            return View("AdminGetir", ID);
        }

        public ActionResult AdminGuncelle(Admin admin)
        {
            var guncellenecekId = db.Admin.Find(admin.ID);
            guncellenecekId.Kullanici = admin.Kullanici;
            guncellenecekId.Sifre = admin.Sifre;
            guncellenecekId.Yetki = admin.Yetki;
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}