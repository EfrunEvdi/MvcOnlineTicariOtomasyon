using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            ViewBag.MainHeader = "Ana Sayfa";
            ViewBag.MainHeaderUrl = "/Dashboard/Index";
            ViewBag.SubHeader = "Cariler";

            var degerler = context.Caris.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            ViewBag.MainHeader = "Cariler";
            ViewBag.MainHeaderUrl = "/Cari/Index";
            ViewBag.SubHeader = "Cari Ekleme Sayfası";

            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            ViewBag.MainHeader = "Cariler";
            ViewBag.MainHeaderUrl = "/Cari/Index";
            ViewBag.SubHeader = "Cari Ekleme Sayfası";

            context.Caris.Add(cari);
            cari.Durum = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = context.Caris.Find(id);
            cari.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            ViewBag.MainHeader = "Cariler";
            ViewBag.MainHeaderUrl = "/Cari/Index";
            ViewBag.SubHeader = "Cari Güncelleme Sayfası";

            var cari = context.Caris.Find(id);
            return View(cari);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cari cari)
        {
            ViewBag.MainHeader = "Cariler";
            ViewBag.MainHeaderUrl = "/Cari/Index";
            ViewBag.SubHeader = "Cari Güncelleme Sayfası";

            if (!ModelState.IsValid)
            {
                return View(cari);
            }
            var GCari = context.Caris.Find(cari.CariID);
            GCari.CariAd = cari.CariAd;
            GCari.CariSoyad = cari.CariSoyad;
            GCari.CariSehir = cari.CariSehir;
            GCari.CariMail = cari.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSatisGecmisi(int id)
        {
            ViewBag.MainHeader = "Cariler";
            ViewBag.MainHeaderUrl = "/Cari/Index";
            ViewBag.SubHeader = "Cari Satış Geçmiş Sayfası";

            var satislar = context.SatisHarekets.Where(x => x.CariID == id).ToList();
            ViewBag.CariAdSoyad = context.Caris.Where(x => x.CariID == id).Select(x => x.CariAd + " " + x.CariSoyad).FirstOrDefault();
            return View(satislar);
        }
    }
}