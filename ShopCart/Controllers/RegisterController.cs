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
    
    public class RegisterController : Controller
    {
        ShopCartEntities model=new ShopCartEntities();
        // GET: Register

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index( Kullanicilar kullanici)
        {
            // Basit bir model doğrulama işlemi örneği
            if (string.IsNullOrEmpty(kullanici.kullaniciAdi) || string.IsNullOrEmpty(kullanici.kullaniciSifre))
            {
                ModelState.AddModelError("", "Kullanıcı adı ve şifre alanları zorunludur.");
                return View();
            }

            // Kullanıcı adının kullanılmadığından emin olmak için örnek bir doğrulama işlemi
            if (model.Kullanicilars.Any(x => x.kullaniciAdi == kullanici.kullaniciAdi))
            {
                ModelState.AddModelError("", "Bu kullanıcı adı zaten kullanımda.");
                return View();
            }
            kullanici.olusturmaTarihi=DateTime.Now;
            model.Kullanicilars.AddOrUpdate(kullanici);
            model.SaveChanges();
            ViewBag.Register = "Register";

            // Başarılı kayıt olduğunda "ThankYou" action'ına yönlendir
            return View("ThankYou");
        }

        [AllowAnonymous]
        public ActionResult ThankYou()
        {
            return View();
        }
    }
}