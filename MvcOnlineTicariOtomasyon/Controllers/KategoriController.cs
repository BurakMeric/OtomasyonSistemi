using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            if (!c.Kategoris.Any())
            {
                k.KategoriId = 1;
            }
            else
            {
                int lastId = c.Kategoris.Max(kat => kat.KategoriId);
                if (lastId == 1 && c.Kategoris.Count() == 1)
                {
                    k.KategoriId = 2;
                }
                else
                {
                    k.KategoriId = lastId + 1;
                }
            }
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            Kategori ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            Kategori kategori = c.Kategoris.Find(id);
            ViewBag.KategoriAd = kategori.KategoriAd;
            return View("KategoriGetir", kategori);

        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            Kategori ktgr = c.Kategoris.Find(k.KategoriId);
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}