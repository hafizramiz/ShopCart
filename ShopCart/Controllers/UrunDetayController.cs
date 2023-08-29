using ShopCart.Models;
using ShopCart.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopCart.Controllers
{
    public class UrunDetayController : Controller
    {
        ShopCartEntities model = new ShopCartEntities();
        // GET: UrunDetay
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index(Urunler u)
        {
            List<SP_GetUrunDetayWithUrunId_Result> urunDetayListesi =model.SP_GetUrunDetayWithUrunId(u.urunId).ToList();
            UrunOzellikleri urunOzellik = model.UrunOzellikleris.FirstOrDefault(x => x.urunOzellikId == u.urunId);
            ViewBag.UrunOzellik=urunOzellik;
            return View(urunDetayListesi);
        }


        [MyAuthorization(Roles="kullanici")]
        [HttpPost]
        public ActionResult Index(Yorumlar yorum)
        {
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];

            if (yorum.yorumMetni!=null)
            {
                yorum.kullaniciId = kullanici.kullaniciId;
                yorum.yorumTarihi=DateTime.Now;
               model.Yorumlars.Add(yorum);
                model.SaveChanges();
            }

            Urunler u = model.Urunlers.FirstOrDefault(x => x.urunId == yorum.urunId);
                return RedirectToAction("Index",u);
        }




       // [MyAuthorization(Roles = "satici")]
        [HttpPost]
        public ActionResult AciklamaEkle(UrunOzellikleri urunOzellikleri)
        {
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];

            if (urunOzellikleri.aciklama != null)
            {
                model.UrunOzellikleris.Add(urunOzellikleri);
                model.SaveChanges();
            }

            Urunler u = model.Urunlers.FirstOrDefault(x => x.urunId == urunOzellikleri.urunOzellikId);
            return RedirectToAction("Index", u);
        }
    }
}