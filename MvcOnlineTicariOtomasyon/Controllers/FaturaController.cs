using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            ViewBag.MainHeader = "Ana Sayfa";
            ViewBag.MainHeaderUrl = "/Dashboard/Index";
            ViewBag.SubHeader = "Faturalar";

            var degerler = context.Faturas.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            ViewBag.MainHeader = "Faturalar";
            ViewBag.MainHeaderUrl = "/Fatura/Index";
            ViewBag.SubHeader = "Fatura Ekleme Sayfası";

            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            ViewBag.MainHeader = "Faturalar";
            ViewBag.MainHeaderUrl = "/Fatura/Index";
            ViewBag.SubHeader = "Fatura Ekleme Sayfası";

            context.Faturas.Add(fatura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult FaturaGuncelle(int id)
        {
            ViewBag.MainHeader = "Faturalar";
            ViewBag.MainHeaderUrl = "/Fatura/Index";
            ViewBag.SubHeader = "Fatura Güncelleme Sayfası";

            var fatura = context.Faturas.Find(id);

            return View(fatura);
        }

        [HttpPost]
        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            ViewBag.MainHeader = "Faturalar";
            ViewBag.MainHeaderUrl = "/Fatura/Index";
            ViewBag.SubHeader = "Fatura Güncelleme Sayfası";

            var GFatura = context.Faturas.Find(fatura.FaturaID);

            GFatura.FaturaSeriNo = fatura.FaturaSeriNo;
            GFatura.FaturaSıraNo = fatura.FaturaSıraNo;
            GFatura.TeslimEden = fatura.TeslimEden;
            GFatura.TeslimAlan = fatura.TeslimAlan;
            GFatura.Toplam = fatura.Toplam;
            GFatura.VergiDairesi = fatura.VergiDairesi;
            GFatura.Tarih = fatura.Tarih;
            GFatura.Saat = fatura.Saat;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            ViewBag.MainHeader = "Faturalar";
            ViewBag.MainHeaderUrl = "/Fatura/Index";
            ViewBag.SubHeader = "Fatura Detay Sayfası";

            var satisDetay = context.FaturaKalems.Where(x => x.FaturaID == id).ToList();
            return View(satisDetay);
        }

        [HttpGet]
        public ActionResult FaturaKalemEkle()
        {
            ViewBag.MainHeader = "Faturalar";
            ViewBag.MainHeaderUrl = "/Fatura/Index";
            ViewBag.SubHeader = "Fatura Kalem Ekleme Sayfası";

            return View();
        }

        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem faturaKalem)
        {
            ViewBag.MainHeader = "Faturalar";
            ViewBag.MainHeaderUrl = "/Fatura/Index";
            ViewBag.SubHeader = "Fatura Kalem Ekleme Sayfası";

            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}