using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context context = new Context();
        public ActionResult Index()
        {
            ViewBag.MainHeader = "Ana Sayfa";
            ViewBag.MainHeaderUrl = "/Dashboard/Index";
            ViewBag.SubHeader = "Yapılacak Listesi";

            var deger1 = context.Caris.Count().ToString();
            var deger2 = context.Uruns.Count().ToString();
            var deger3 = context.Personels.Count().ToString();
            var deger4 = context.Kategoris.Count().ToString();

            ViewBag.Deger1 = deger1;
            ViewBag.Deger2 = deger2;
            ViewBag.Deger3 = deger3;
            ViewBag.Deger4 = deger4;

            var yapilacaklar = context.Yapilacaks.ToList();

            return View(yapilacaklar);
        }
    }
}