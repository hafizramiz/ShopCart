using ShopCart.Models;
using ShopCart.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopCart.Controllers
{
    //[Authorize]
    public class KategoriController : Controller
    {
        ShopCartEntities model=new ShopCartEntities();
        // GET: Kategori
        [AllowAnonymous]
        public ActionResult KategoriGoruntule(int id)
        {
            // Burda urunleri cektim, Bunun yaninda kategorileri de cekmek istiyorum
            List<Kategoriler> kategoriler = model.Kategorilers.ToList();
            ViewBag.Kategoriler = kategoriler;


            // Burda ViewBag ile sepet blgilerini de arayuze gonderecem.

            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
            // Giris yapan user var.If kontrolu yapcam
            if (kullanici != null)
            {
                Sepetler musteriSepeti = model.Sepetlers.FirstOrDefault(x => x.musteriId == kullanici.kullaniciId);
                ViewBag.MusteriSepeti = musteriSepeti;
                List<SP_GETFAVORIDETAYWITHID_Result> FavoriDetayListesi = model.SP_GETFAVORIDETAYWITHID(kullanici.kullaniciId).ToList();
                ViewBag.FavoriDetayListesi = FavoriDetayListesi;
                ViewBag.Kullanici = kullanici;
            }

            List<Urunler> urunler=model.Urunlers.Where(x=>x.kategoriId==id).ToList();
            return View(urunler);
        }

        // Burdan sonra degistircem


        [MyAuthorization(Roles = "admin")]
        [HttpGet]
        public ActionResult Index()
        {
            List<Kategoriler> kategoriler=model.Kategorilers.ToList();
            return View(kategoriler);
        }



        [MyAuthorization(Roles = "admin")]
        [HttpPost]
        public ActionResult Index(Kategoriler kategori)
        {
            if (kategori.kategoriAdi == null)
            {

                ModelState.AddModelError("", "Gerekli alanlari doldurun");
                return View();
            }
            else
            {
                model.Kategorilers.AddOrUpdate(kategori);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [MyAuthorization(Roles = "admin")]
        [HttpPost]
        public void KategoriSil(int id) 
        {
            Kategoriler kategori = model.Kategorilers.FirstOrDefault(x => x.kategoriId == id);
            if (kategori != null)
            {
                model.Kategorilers.Remove(kategori);
                model.SaveChanges();
            }
        }

    }
}