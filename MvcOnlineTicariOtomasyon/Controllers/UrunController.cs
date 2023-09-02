using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        Context context = new Context();

        public ActionResult Index()
        {
            ViewBag.MainHeader = "Ana Sayfa";
            ViewBag.MainHeaderUrl = "/Dashboard/Index";
            ViewBag.SubHeader = "Ürünler";

            var urunler = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            ViewBag.MainHeader = "Urunler";
            ViewBag.MainHeaderUrl = "/Urun/Index";
            ViewBag.SubHeader = "Urun Ekleme Sayfası";

            List<SelectListItem> kategori = (from x in context.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.kategoriAd = kategori;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            ViewBag.MainHeader = "Urunler";
            ViewBag.MainHeaderUrl = "/Urun/Index";
            ViewBag.SubHeader = "Urun Ekleme Sayfası";

            List<SelectListItem> kategori = (from x in context.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.kategoriAd = kategori;
            context.Uruns.Add(urun);
            urun.Durum = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = context.Uruns.Find(id);
            urun.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            ViewBag.MainHeader = "Ürünler";
            ViewBag.MainHeaderUrl = "/Ürün/Index";
            ViewBag.SubHeader = "Ürün Güncelleme Sayfası";

            var urun = context.Uruns.Find(id);
            List<SelectListItem> kategori = (from x in context.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.kategoriAd = kategori;
            return View(urun);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Urun urun)
        {
            ViewBag.MainHeader = "Ürünler";
            ViewBag.MainHeaderUrl = "/Ürün/Index";
            ViewBag.SubHeader = "Ürün Güncelleme Sayfası";

            var GUrun = context.Uruns.Find(urun.UrunID);
            GUrun.UrunAd = urun.UrunAd;
            GUrun.Marka = urun.Marka;
            GUrun.Stok = urun.Stok;
            GUrun.AlisFiyat = urun.AlisFiyat;
            GUrun.SatisFiyat = urun.SatisFiyat;
            GUrun.UrunGorsel = urun.UrunGorsel;
            GUrun.Durum = true;
            List<SelectListItem> kategori = (from x in context.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.kategoriAd = kategori;
            GUrun.KategoriID = urun.KategoriID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}