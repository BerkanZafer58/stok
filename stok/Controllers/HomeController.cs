using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stok.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(string Kullanici, string Sifre)
        {
            if(Kullanici == "deneme" && Sifre == "123")
            {
                Session.Add("Yonetici", true);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult CikisYap()
        {
             Session.Clear();
            return RedirectToAction("Index", "Home");

        }

    }
}