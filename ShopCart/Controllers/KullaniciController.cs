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
    public class KullaniciController : Controller
    {
        ShopCartEntities model=new ShopCartEntities();
        [MyAuthorization(Roles = "admin")]
        // GET: Kullanici
        [HttpGet]
        public ActionResult Index()
        {
            Kullanicilar kullanici = (Kullanicilar)Session["LoggedInUser"];
           List<Kullanicilar>tumKullanicilar= model.Kullanicilars.Where(x=>x.kullaniciId!=kullanici.kullaniciId).ToList();
            
            return View(tumKullanicilar);
        }
    }
}