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
    public class LoginController : Controller
    {
        MvcLibraryDBEntities db = new MvcLibraryDBEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult GirisYap(Uyeler uye)
        {
            var giris = db.Uyeler.FirstOrDefault(x => x.Mail == uye.Mail && x.Sifre == uye.Sifre);
            if (giris != null)
            {
                FormsAuthentication.SetAuthCookie(giris.Mail, false);
                Session["Mail"] = giris.Mail.ToString();

                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
          
        }
    }
}
