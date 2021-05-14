using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Controllers
{
    public class IslemController : Controller
    {

        MvcLibraryDBEntities db = new MvcLibraryDBEntities();
        public ActionResult Index()
        {
            var islem = db.Hareketler.Where(x => x.IslemDurum == true).ToList();
            return View(islem);
        }
    }
}