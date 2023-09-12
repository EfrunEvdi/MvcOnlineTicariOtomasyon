using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context context = new Context();

        public ActionResult Index()
        {
            ViewBag.MainHeader = "Ana Sayfa";
            ViewBag.MainHeaderUrl = "/Dashboard/Index";
            ViewBag.SubHeader = "Ürün Detayı";

            IEnumerable sinif = new IEnumerable();
            // var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
            sinif.Uruns = context.Uruns.Where(x => x.UrunID == 1).ToList();
            sinif.UrunDetays = context.UrunDetays.Where(y => y.UrunDetayID == 1).ToList();
            return View(sinif);
        }
    }
}