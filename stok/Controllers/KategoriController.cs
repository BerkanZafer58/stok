using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stok.Models.entity;
using PagedList;
using PagedList.Mvc;

namespace stok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        stokEntities db = new stokEntities();
        public ActionResult Index(int Sayfa=1)
        {
            if (Convert.ToBoolean(Session["Yonetici"]) == true)
            {
                var degerler = db.TBLKATEGORILER.ToList().ToPagedList(Sayfa, 5);
                return View(degerler);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER P1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
                
            }
            db.TBLKATEGORILER.Add(P1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL (int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}