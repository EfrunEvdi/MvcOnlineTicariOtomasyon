using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            ViewBag.MainHeader = "Ana Sayfa";
            ViewBag.MainHeaderUrl = "/Dashboard/Index";
            ViewBag.SubHeader = "Satışlar";

            var degerler = context.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            ViewBag.MainHeader = "Satışlar";
            ViewBag.MainHeaderUrl = "/Satis/Index";
            ViewBag.SubHeader = "Satış Ekleme Sayfası";

            List<SelectListItem> urun = (from x in context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            ViewBag.urunAd = urun;

            List<SelectListItem> cari = (from x in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();
            ViewBag.cariAd = cari;

            List<SelectListItem> personel = (from x in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            ViewBag.personelAd = personel;

            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(SatisHareket satis)
        {
            ViewBag.MainHeader = "Satışlar";
            ViewBag.MainHeaderUrl = "/Satis/Index";
            ViewBag.SubHeader = "Satış Ekleme Sayfası";

            List<SelectListItem> urun = (from x in context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            ViewBag.urunAd = urun;

            List<SelectListItem> cari = (from x in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();
            ViewBag.cariAd = cari;

            List<SelectListItem> personel = (from x in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            ViewBag.personelAd = personel;

            satis.Tarih = DateTime.Now;
            context.SatisHarekets.Add(satis);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SatisGuncelle(int id)
        {
            ViewBag.MainHeader = "Satışlar";
            ViewBag.MainHeaderUrl = "/Satis/Index";
            ViewBag.SubHeader = "Satış Güncelleme Sayfası";

            List<SelectListItem> urun = (from x in context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            ViewBag.urunAd = urun;

            List<SelectListItem> cari = (from x in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();
            ViewBag.cariAd = cari;

            List<SelectListItem> personel = (from x in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            ViewBag.personelAd = personel;

            var satisHareket = context.SatisHarekets.Find(id);

            return View(satisHareket);
        }

        [HttpPost]
        public ActionResult SatisGuncelle(SatisHareket satisHareket)
        {
            ViewBag.MainHeader = "Satışlar";
            ViewBag.MainHeaderUrl = "/Satis/Index";
            ViewBag.SubHeader = "Satış Güncelleme Sayfası";

            var GSatisHareket = context.SatisHarekets.Find(satisHareket.SatisID);

            List<SelectListItem> urun = (from x in context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            ViewBag.urunAd = urun;

            List<SelectListItem> cari = (from x in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();
            ViewBag.cariAd = cari;

            List<SelectListItem> personel = (from x in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            ViewBag.personelAd = personel;

            GSatisHareket.Tarih = DateTime.Now;
            GSatisHareket.Adet = satisHareket.Adet;
            GSatisHareket.Fiyat = satisHareket.Fiyat;
            GSatisHareket.ToplamTutar = satisHareket.ToplamTutar;
            GSatisHareket.CariID = satisHareket.CariID;
            GSatisHareket.PersonelID = satisHareket.PersonelID;
            GSatisHareket.UrunID = satisHareket.UrunID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            ViewBag.MainHeader = "Satışlar";
            ViewBag.MainHeaderUrl = "/Satis/Index";
            ViewBag.SubHeader = "Satış Detay Sayfası";

            var satisDetay = context.SatisHarekets.Where(x=>x.SatisID == id).ToList();
            return View(satisDetay);
        }
    }
}