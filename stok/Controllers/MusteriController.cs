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
            if(Convert.ToBoolean(Session["Yonetici"]) == true)
            {
                var degerler = db.TBLMUSTERILER.ToList();
                return View(degerler);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
          
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER P1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");

            }
            db.TBLMUSTERILER.Add(P1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mus);

        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteri = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}