using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman

        Context context = new Context();

        public ActionResult Index()
        {
            ViewBag.MainHeader = "Ana Sayfa";
            ViewBag.MainHeaderUrl = "/Dashboard/Index";
            ViewBag.SubHeader = "Departmanlar";

            var departmanlar = context.Departmans.Where(x => x.Durum == true).ToList();
            return View(departmanlar);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            ViewBag.MainHeader = "Departmanlar";
            ViewBag.MainHeaderUrl = "/Departman/Index";
            ViewBag.SubHeader = "Departman Ekleme Sayfası";

            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            ViewBag.MainHeader = "Departmanlar";
            ViewBag.MainHeaderUrl = "/Departman/Index";
            ViewBag.SubHeader = "Departman Ekleme Sayfası";

            context.Departmans.Add(departman);
            departman.Durum = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = context.Departmans.Find(id);
            departman.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanGuncelle(int id)
        {
            ViewBag.MainHeader = "Departmanlar";
            ViewBag.MainHeaderUrl = "/Departman/Index";
            ViewBag.SubHeader = "Departman Güncelleme Sayfası";

            var departman = context.Departmans.Find(id);
            return View(departman);
        }

        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman departman)
        {
            ViewBag.MainHeader = "Departmanlar";
            ViewBag.MainHeaderUrl = "/Departman/Index";
            ViewBag.SubHeader = "Departman Güncelleme Sayfası";

            var GDepartman = context.Departmans.Find(departman.DepartmanID);
            GDepartman.DepartmanAd = departman.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            ViewBag.MainHeader = "Departmanlar";
            ViewBag.MainHeaderUrl = "/Departman/Index";
            ViewBag.SubHeader = "Departman Detay Sayfası";

            var personeller = context.Personels.Where(x => x.DepartmanID == id).ToList();
            ViewBag.DepartmanIsmi = context.Departmans.Where(x => x.DepartmanID == id).Select(x => x.DepartmanAd).FirstOrDefault();
            return View(personeller);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            ViewBag.MainHeader = "Departmanlar";
            ViewBag.MainHeaderUrl = "/Departman/Index";
            ViewBag.SubHeader = "Personel Satış Listesi";

            var satislar = context.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            ViewBag.PersonelAdSoyad = context.Personels.Where(x => x.PersonelID == id).Select(x => x.PersonelAd + " " + x.PersonelSoyad).FirstOrDefault();
            return View(satislar);
        }
    }
}