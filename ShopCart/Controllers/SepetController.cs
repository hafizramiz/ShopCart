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
    public class SepetController : Controller
    {
        // GET: Sepet
       
        ShopCartEntities model = new ShopCartEntities();
       
        // GET: Urun
        [MyAuthorization(Roles = "kullanici")]
        [HttpGet]
        public ActionResult Index ()
        {
            int toplamTutar = 0;

            //Giris yapan kullanici:
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
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

            List<SP_GETSEPETDETAYWITHID_Result> SepetDetayListesi = model.SP_GETSEPETDETAYWITHID(kullanici.kullaniciId).ToList();

            return View(SepetDetayListesi);
        }


        
        public ActionResult SepeteEkle( Urunler u)
        {

            // Burda ekleme yaparken Urunun stok miktarini da kontrol edip ona gore Sepete eklemem gerekiyor.

            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
            Urunler urun = model.Urunlers.Find(u.urunId);
            // Stok kontrolu yap
            if (urun.urunStokMiktari>= 1){
                // Sepete Ekle
                Sepetler musteriSepeti = model.Sepetlers.FirstOrDefault(x => x.musteriId == kullanici.kullaniciId);
                if (musteriSepeti == null)
                {
                    // Burda musteriye ait bir sepet yok. Yeni sepet olustur.

                    Sepetler musteriYeniSepet = new Sepetler();
                    musteriYeniSepet.musteriId = kullanici.kullaniciId;
                    musteriYeniSepet.toplamTutar = u.urunFiyati;
                    // Ilgili sepeti veritabanina ekle   
                    model.Sepetlers.Add(musteriYeniSepet);
                    model.SaveChanges();

                    // Ayni zamanda Yeni sepetUrun de olusturcam ve ekliycem.
                    SepetUrun yeniSepetUrun = new SepetUrun();
                    yeniSepetUrun.sepetId = musteriYeniSepet.sepetId;
                    yeniSepetUrun.urunId = u.urunId;
                    yeniSepetUrun.urunSayisi++;
                    // yeni olusturdugum sepet urunu dbye ekle ve kaydet
                    model.SepetUruns.Add(yeniSepetUrun);
                    model.SaveChanges();

                }
                else
                {
                    List<SepetUrun> sepetUrunListesi = model.SepetUruns.Where(x => x.sepetId == musteriSepeti.sepetId).ToList();
                    SepetUrun sepetUrunSatiri = sepetUrunListesi.FirstOrDefault(x => x.urunId == u.urunId);

                    if (sepetUrunSatiri == null)
                    {
                        //  sepetUrunSatiri==null o idye iliskin urun yok demektir. Yeni ekle
                        SepetUrun yeniSepetUrunSatiri = new SepetUrun();
                        yeniSepetUrunSatiri.sepetId = musteriSepeti.sepetId;
                        yeniSepetUrunSatiri.urunId = u.urunId;
                        yeniSepetUrunSatiri.urunSayisi++;

                        model.SepetUruns.Add(yeniSepetUrunSatiri);
                        model.SaveChanges();
                        // Urun sayisini artirdiktan sonra Toplam tutari da artir ve dbye kaydet
                        musteriSepeti.toplamTutar += u.urunFiyati;
                        model.Sepetlers.AddOrUpdate(musteriSepeti);
                        model.SaveChanges();
                    }
                    else
                    {

                        sepetUrunSatiri.urunSayisi++;
                        model.SepetUruns.AddOrUpdate(sepetUrunSatiri);
                        model.SaveChanges();
                        musteriSepeti.toplamTutar += u.urunFiyati;
                        model.Sepetlers.AddOrUpdate(musteriSepeti);
                        model.SaveChanges();
                    }
                }
            }
            else
            {
                // Hata mesaji goster
                //ModelState.AddModelError("", "Ilgili Urun stokta mevcut degil");
                ViewBag.Hata = "Ilgili Urun stokta mevcut degil";

            }

            return RedirectToAction("Anasayfa","Guvenlik");
        }

        
        // Sepetten Cikart Action'i bir view dondurmeyecek
        public void SepettenCikart(int id)
        {
            //  Burda sepetten cikarma yapcam
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
            // Kullanicinin sepet idsini bulcam.Bu sepet id icinde birden fazla urun var 
            // O urunler icinde parametre olarak gelen idye denk satiri silcem
            Sepetler musteriSepeti = model.Sepetlers.FirstOrDefault(x => x.musteriId == kullanici.kullaniciId);
            // musteri sepetinin idsine denk gelen butun satirlari getir.
            List<SepetUrun> sepetUrunSatirListesi= model.SepetUruns.Where(x => x.sepetId == musteriSepeti.sepetId && x.urunId == id).ToList();
            SepetUrun sepetUrunSatiri = sepetUrunSatirListesi[0];
            //SepetUrun sepetUrunSatiri = model.SepetUruns.FirstOrDefault(x => x.urunId == id);
            if (sepetUrunSatiri != null)
            {
                // Urun id ye urunu bul toplam tutardan ilgili urunun fiyatini cikart
                Urunler silinenUrun = model.Urunlers.Find(id);
                int silinecekTutar = silinenUrun.urunFiyati * sepetUrunSatiri.urunSayisi;
                musteriSepeti.toplamTutar -= silinecekTutar;
                model.SepetUruns.Remove(sepetUrunSatiri);
                model.SaveChanges();
                model.Sepetlers.AddOrUpdate(musteriSepeti);
                model.SaveChanges();
            }
        }
    }
}