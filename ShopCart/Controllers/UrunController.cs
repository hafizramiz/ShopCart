using ShopCart.Models;
using ShopCart.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopCart.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        ShopCartEntities model = new ShopCartEntities();
        // GET: Urun
        [MyAuthorization(Roles ="satici")]
        [HttpGet]
        public ActionResult Index()
        {
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
            List<Urunler> urunler = model.Urunlers.Where(u => kullanici.kullaniciId == u.saticiId).ToList();
            return View(urunler);
        }

        [MyAuthorization(Roles = "satici")]
        [HttpGet]

        public ActionResult UrunEkle() { 
            List<Markalar>markalar=model.Markalars.ToList(); 
            List<Kategoriler>kategoriler = model.Kategorilers.ToList();
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];

            ViewBag.Markalar = markalar;
            ViewBag.Kategoriler = kategoriler;
            ViewBag.SaticiId = kullanici.kullaniciId;
            ViewBag.UrunEkle = true;
            Urunler urun = new Urunler();
            return View(urun);
        }



        [MyAuthorization(Roles ="satici")]
        [HttpPost]
        public ActionResult UrunEkle(Urunler urun)
        {
            if(urun.urunAdi == null)
            {

                ModelState.AddModelError("", "Gerekli alanlari doldurun");
                return View();
            }
            else
            {

                model.Urunlers.AddOrUpdate(urun);
                model.SaveChanges();
                return RedirectToAction("Index");

            }
        }


        [HttpGet]
        [MyAuthorization(Roles = "satici")]

        public ActionResult UrunGuncelle(int id)
        {
            List<Markalar> markalar = model.Markalars.ToList();
            List<Kategoriler> kategoriler = model.Kategorilers.ToList();
            //List<GetUrunGuncelleDetayWithId_Result> urunGuncelle = model.GetUrunGuncelleDetayWithId(id).ToList();
            ViewBag.Markalar = markalar;
            ViewBag.Kategoriler = kategoriler;

             Urunler urun = model.Urunlers.FirstOrDefault(x => x.urunId == id);
           // Kategoriler kategori=model.Kategoriler.FirstOrDefault(x=>x.kategoriId == u.kategoriId);
            //Markalar marka=model.Markalar.FirstOrDefault(x=>x.markaId == u.markaId);
            // ViewBag.Marka = marka;
            //ViewBag.Kategori=kategori;
            ViewBag.SaticiId = urun.saticiId;
            return View("UrunEkle", urun);
        }

        [MyAuthorization (Roles ="satici")]
        [HttpPost]
        public ActionResult UrunGuncelle(Urunler urun)
        {
            if (urun.urunAdi == null)
            {
                ModelState.AddModelError("", "Gerekli alanlari doldurun");
                return View();
            }
            else
            {
                /// Burda marka bilgisi degisince yeni kayit atiyor.
                model.Urunlers.AddOrUpdate(urun);
                model.SaveChanges();
                return RedirectToAction("Index");

            }
        }

        [MyAuthorization(Roles = "satici")]
        [HttpPost]


        // Urun sil Action'i bir view dondurmeyecek
        public void UrunSil(int id)
        {
            Urunler urun=model.Urunlers.FirstOrDefault(x=>x.urunId==id);
            if (urun != null)
            {
                model.Urunlers.Remove(urun); 
                model.SaveChanges();
            }
        }

    }
}