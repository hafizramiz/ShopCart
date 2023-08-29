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
    public class KargoController : Controller
    {
        // GET: Kargo
        ShopCartEntities model=new ShopCartEntities();
        [MyAuthorization(Roles = "kullanici")]
        [HttpGet]
        public ActionResult Index()
        {
            List< KargoBilgisi > kargoBilgisi= model.KargoBilgisis.ToList();
            List<Kargolar> kargolar=model.Kargolars.ToList();
            ViewBag.Kargolar=kargolar;
            return View(kargoBilgisi);
        }



        [HttpPost]
        public ActionResult Index(KargoBilgisi kargoBilgisi)
        {
            // aldigim kargo bilgisini kaydet, idyi gonder

            
            if(kargoBilgisi.il==null&& kargoBilgisi.ilce==null&&kargoBilgisi.acikAdres==null)
            {
                ModelState.AddModelError("", "Gerekli alanlari doldurun");
                return View();
            }
            else
            {
                model.KargoBilgisis.Add(kargoBilgisi);
                model.SaveChanges();
                return RedirectToAction("Index", "Satis", kargoBilgisi);
            }
        }
    }
}