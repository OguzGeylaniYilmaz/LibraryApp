using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var deger = db.Admin.FirstOrDefault(x => x.Kullanici == admin.Kullanici && x.Sifre == admin.Sifre);
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.Kullanici, false);
                Session["Kullanici"] = deger.Kullanici.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
          
        }
    }
}