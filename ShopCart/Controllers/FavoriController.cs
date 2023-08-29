using ShopCart.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopCart.Controllers
{
    public class FavoriController : Controller
    {
        ShopCartEntities model=new ShopCartEntities();
        // GET: Favori
        public ActionResult Index()
        {
            //Giris yapan kullanici:
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
            List<SP_GETFAVORIDETAYWITHID_Result> FavoriDetayListesi = model.SP_GETFAVORIDETAYWITHID(kullanici.kullaniciId).ToList();

            return View(FavoriDetayListesi);
        }



        public ActionResult FavoriEkle(Urunler u) {
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
            Urunler urun = model.Urunlers.Find(u.urunId);
            Favoriler musteriFavori = model.Favorilers.FirstOrDefault(x => x.musteriId == kullanici.kullaniciId);
            if (musteriFavori == null)
            {
                // Burda musteriye ait bir favori yok. Yeni favori olustur.
                Favoriler musteriYeniFavori= new Favoriler();
                musteriYeniFavori.musteriId=kullanici.kullaniciId;
                // Ilgili favoriyi veritabanina ekle   
                model.Favorilers.Add(musteriYeniFavori);
                model.SaveChanges();
                // Ayni zamanda Yeni FavoriUrun de olusturcam ve ekliycem.
                FavoriUrun yeniFavoriUrun = new FavoriUrun();
                yeniFavoriUrun.favoriId = musteriYeniFavori.favoriId;
                yeniFavoriUrun.urunId = u.urunId;
                // yeni olusturdugum favori urunu dbye ekle ve kaydet
                model.FavoriUruns.Add(yeniFavoriUrun);
                model.SaveChanges();
            }
            else
            {
                List<FavoriUrun> favoriUrunListesi = model.FavoriUruns.Where(x => x.favoriId == musteriFavori.favoriId).ToList();
                FavoriUrun favoriUrunSatiri = favoriUrunListesi.FirstOrDefault(x => x.urunId == u.urunId);
                if(favoriUrunSatiri== null)
                {
                    //  favoriUrunSatiri==null ise o idye iliskin urun yok demektir. Yeni ekle
                    FavoriUrun yeniFavoriUrunSatiri = new FavoriUrun();
                    yeniFavoriUrunSatiri.favoriId = musteriFavori.favoriId;
                    yeniFavoriUrunSatiri.urunId = u.urunId;


                    model.FavoriUruns.Add(yeniFavoriUrunSatiri);
                    model.SaveChanges();

                }
                else
                {
                    // Zaten urun favori listesinde mevcut. Kullaniciya bilgi ver
                }
            }

            return RedirectToAction("Anasayfa", "Guvenlik");

        }

        public void FavorilerdenCikart(int id)
        {
            //  Burda favorilerden cikarma yapcam
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
            // Kullanicinin favori idsini bulcam.Bu favori id icinde birden fazla urun var 
            // O urunler icinde parametre olarak gelen idye denk satiri silcem
            Favoriler musteriFavori = model.Favorilers.FirstOrDefault(x => x.musteriId == kullanici.kullaniciId);
            // musteri favori idsine denk gelen butun satirlari getir.
            List<FavoriUrun> favoriUrunSatirListesi = model.FavoriUruns.Where(x => x.favoriId == musteriFavori.favoriId && x.urunId == id).ToList();
            FavoriUrun favoriUrunSatiri = favoriUrunSatirListesi[0];
            if (favoriUrunSatiri != null)
            {
                model.FavoriUruns.Remove(favoriUrunSatiri);
                model.SaveChanges();
            }
        }

    }
}