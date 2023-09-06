using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            ViewBag.MainHeader = "Ana Sayfa";
            ViewBag.MainHeaderUrl = "/Dashboard/Index";
            ViewBag.SubHeader = "Personeller";

            var degerler = context.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            ViewBag.MainHeader = "Personeller";
            ViewBag.MainHeaderUrl = "/Personel/Index";
            ViewBag.SubHeader = "Personel Ekleme Sayfası";

            List<SelectListItem> departman = (from x in context.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanID.ToString()
                                              }).ToList();

            ViewBag.departmanAd = departman;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            ViewBag.MainHeader = "Personeller";
            ViewBag.MainHeaderUrl = "/Personel/Index";
            ViewBag.SubHeader = "Personel Ekleme Sayfası";

            List<SelectListItem> departman = (from x in context.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanID.ToString()
                                              }).ToList();
            ViewBag.departmanAd = departman;

            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            ViewBag.MainHeader = "Personeller";
            ViewBag.MainHeaderUrl = "/Personel/Index";
            ViewBag.SubHeader = "Personel Güncelleme Sayfası";

            List<SelectListItem> departman = (from x in context.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanID.ToString()
                                              }).ToList();


            ViewBag.departmanAd = departman;
            
            var personel = context.Personels.Find(id);
            return View(personel);
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel)
        {
            ViewBag.MainHeader = "Personeller";
            ViewBag.MainHeaderUrl = "/Personel/Index";
            ViewBag.SubHeader = "Personel Güncelleme Sayfası";

            List<SelectListItem> departman = (from x in context.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanID.ToString()
                                              }).ToList();

            ViewBag.departmanAd = departman;

            var GPersonel = context.Personels.Find(personel.PersonelID);
            GPersonel.PersonelAd = personel.PersonelAd;
            GPersonel.PersonelSoyad = personel.PersonelSoyad;
            GPersonel.PersonelGorsel = personel.PersonelGorsel;
            GPersonel.DepartmanID = personel.DepartmanID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}