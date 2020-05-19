using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            if (Convert.ToBoolean(Session["Yonetici"]) == true)
            {
                var degerler = db.TBLURUNLER.ToList();
                return View(degerler);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler=(from i in db.TBLKATEGORILER.ToList()
                                            select new SelectListItem
                                          {
                                             Text = i.KATEGORIAD,
                                             Value = i.KATEGORIID.ToString()
                                          }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m =>m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            
            return View("UrunGetir", urun);


         }
        public ActionResult Guncelle(TBLURUNLER P)
        {
            var urun = db.TBLURUNLER.Find(P.URUNID);
            urun.URUNAD = P.URUNAD;
            urun.MARKA = P.MARKA;
            urun.STOK = P.STOK;
            urun.FIYAT = P.FIYAT;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == P.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}