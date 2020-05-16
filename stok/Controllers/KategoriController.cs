using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stok.Models.entity;

namespace stok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        stokEntities db = new stokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER P1)
        {
            db.TBLKATEGORILER.Add(P1);
            db.SaveChanges();
            return View();
        }
    }
}