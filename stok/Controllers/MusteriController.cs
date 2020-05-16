using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stok.Models.entity;

namespace stok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        stokEntities db = new stokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER P1)
        {
            db.TBLMUSTERILER.Add(P1);
            db.SaveChanges();
            return View();
        }
    }
}