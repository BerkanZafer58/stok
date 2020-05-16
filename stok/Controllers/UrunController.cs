using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stok.Models.entity;

namespace stok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        stokEntities db = new stokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER P1)
        {
            db.TBLURUNLER.Add(P1);
            db.SaveChanges();
            return View();
        }
    }
}