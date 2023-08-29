using ShopCart.Models;
using ShopCart.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopCart.Controllers
{
    [Authorize]
    public class SatisController : Controller
    {
        ShopCartEntities model=new ShopCartEntities();
        // GET: Satis
        [HttpGet]
        public ActionResult Index(KargoBilgisi kB)
        {
            //Giris yapan kullanici:
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
            List<SP_GETSEPETDETAYWITHID_Result> SepetDetayListesi = model.SP_GETSEPETDETAYWITHID(kullanici.kullaniciId).ToList();
            SP_GETSEPETDETAYWITHID_Result SepetDetay = SepetDetayListesi[0];
            //ViewBag.KargoBilgileri = model.KargoBilgileri.ToList();
            ViewBag.OdemeYontemleri=model.OdemeYontemleris.ToList();
            ViewBag.Bolgeler = model.Bolgelers.ToList();
            ViewBag.KargoBilgisi = kB;
            int toplamTutar = 0;

                Sepetler musteriSepeti = model.Sepetlers.FirstOrDefault(x => x.musteriId == kullanici.kullaniciId);
                if (musteriSepeti != null)
                {
                    List<SepetUrun> musteriSepetUrunListesi = model.SepetUruns.Where(x => x.sepetId == musteriSepeti.sepetId).ToList();
                    foreach (SepetUrun sp in musteriSepetUrunListesi)
                    {
                        Urunler tekUrun = model.Urunlers.FirstOrDefault(x => x.urunId == sp.urunId);
                        int araToplam = tekUrun.urunFiyati * sp.urunSayisi;
                        toplamTutar += araToplam;
                    }

                }
                ViewBag.ToplamTutar = toplamTutar;
                return View(SepetDetay);
        }


        [MyAuthorization(Roles = "kullanici")]
        [HttpPost]

        // SatisYap Action'i bir view dondurmeyecek
        public ActionResult Index(SatislarTablosu s) 
        {
            s.satisTarihi=DateTime.Now;
            model.SatislarTablosus.Add(s);
            model.SaveChanges();
            // Satis kaydindan sonra. Sepet Urun icinden sil.Bu sepetle ilgili butun kayitlari getir.
            List<SepetUrun>sepetUrunListesi=model.SepetUruns.Where(x=>x.sepetId==s.sepetId).ToList();
            foreach(SepetUrun spUrn in sepetUrunListesi)
            {
                // Silmeden once urunstok miktarindan dus
                Urunler urun=model.Urunlers.FirstOrDefault(x=>x.urunId==spUrn.urunId);
                urun.urunStokMiktari -= spUrn.urunSayisi;
                model.SepetUruns.Remove(spUrn);
            }
            model.SaveChanges();
            return RedirectToAction("ThankYou","Register");
        }



        [MyAuthorization(Roles = "admin")]
        [HttpGet]
        public ActionResult TumSatislar()
            {
            List<SP_GetSalesInfo_Result>satisDetayListesi=model.SP_GetSalesInfo().ToList();
            return View();
        }
    }
}