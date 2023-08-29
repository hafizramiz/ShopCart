using ShopCart.Models;
using ShopCart.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ShopCart.Controllers
{
    [Authorize]  // Disardan slash yapip erisim yapilamasin diye bunu yaptim
    public class GuvenlikController : Controller
    {
        ShopCartEntities model=new ShopCartEntities();
        [AllowAnonymous]
        // GET: Guvenlik
        [HttpGet]
       public ActionResult Anasayfa()
       {
            // Burda urunleri cektim, Bunun yaninda kategorileri de cekmek istiyorum
            List<Kategoriler> kategoriler = model.Kategorilers.ToList();
            ViewBag.Kategoriler = kategoriler;


            // Burda ViewBag ile sepet blgilerini de arayuze gonderecem.

            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
            int toplamTutar = 0;
            // Giris yapan user var.If kontrolu yapcam
            if(kullanici != null) {

                Sepetler musteriSepeti=model.Sepetlers.FirstOrDefault(x=>x.musteriId==kullanici.kullaniciId);
                if (musteriSepeti != null)
                {
                    List<SepetUrun> musteriSepetUrunListesi = model.SepetUruns.Where(x => x.sepetId ==musteriSepeti.sepetId).ToList();
                    foreach(SepetUrun sp in musteriSepetUrunListesi)
                    {
                        Urunler tekUrun = model.Urunlers.FirstOrDefault(x => x.urunId == sp.urunId);
                        int araToplam = tekUrun.urunFiyati * sp.urunSayisi;
                        toplamTutar += araToplam;
                    }

                }
               
                ViewBag.ToplamTutar = toplamTutar;
               
                List<SP_GETFAVORIDETAYWITHID_Result> FavoriDetayListesi = model.SP_GETFAVORIDETAYWITHID(kullanici.kullaniciId).ToList();
                ViewBag.FavoriDetayListesi=FavoriDetayListesi;
                ViewBag.Kullanici=kullanici;
            }

            List<Urunler> urunler = model.Urunlers.ToList();
            return View(urunler);
       }


       
        /// Kullanicinin Id sini anasayfaya nasil gonderecem?
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Kullanicilar kullanici) {
            Kullanicilar k=model.Kullanicilars.FirstOrDefault(x=>x.kullaniciAdi==kullanici.kullaniciAdi && x.kullaniciSifre==kullanici.kullaniciSifre);
        if (k==null)
            {
                /// Burda ekrana bir hata gonderiyorum. Ekrandan onu alip gostermem gerek.
                /// Burdan ViewBag ile gonderdigim hata anasayfaya mi gidecek yoksa layouta mi?
                // Burdaki cozum: Baska Login sayfasina atmak olacak.
                
                ViewBag.Hata = "Kullanici adi ve ya sifre hatali";
                TempData["Hata"] = "Kullanıcı adı ve ya şifre hatalı";
                return View("LoginForm");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(k.kullaniciAdi, false);
                //TempData["KullaniciId"] = k.kullaniciId;
                HttpContext.Session["LoggedInUser"] = k;

                return RedirectToAction("Anasayfa",k);   
            }
        }


        [MyAuthorization]
        public ActionResult Logout() {
         
           FormsAuthentication.SignOut();

            return RedirectToAction("Anasayfa");
        }


        public ActionResult Hata()
        {
            ViewBag.Hata = "Hata";
            return View();
        }

    }
}