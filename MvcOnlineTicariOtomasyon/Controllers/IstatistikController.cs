using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context context = new Context();
        public ActionResult Index()
        {
            ViewBag.MainHeader = "Ana Sayfa";
            ViewBag.MainHeaderUrl = "/Dashboard/Index";
            ViewBag.SubHeader = "İstatistikler";

            var deger1 = context.Caris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = context.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = context.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = context.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = context.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from product in context.Uruns where (product.Durum == true) select product.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = context.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;

            var deger8 =
                (from product in context.Uruns orderby product.SatisFiyat descending select product.UrunAd)
                .FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = (from product in context.Uruns
                          where (product.Durum == true)
                          orderby product.SatisFiyat ascending
                          select product.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            var deger10 = context.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            var deger11 = context.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;

            var deger12 = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger13 = context.Uruns.Where(p => p.UrunID == (context.SatisHarekets.GroupBy(x => x.UrunID).OrderByDescending(z => z.Count())
                .Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = context.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            DateTime today = DateTime.Today;
            var deger15 = context.SatisHarekets.Count(x => x.Tarih == today).ToString();
            ViewBag.d15 = deger15;

            var deger16 = context.SatisHarekets.Where(x => x.Tarih == today).Sum(x => (decimal?)x.ToplamTutar).ToString();
            if (string.IsNullOrEmpty(deger16))
            {
                deger16 = "0";
            }
            ViewBag.d16 = deger16;
            return View();
        }
    }
}