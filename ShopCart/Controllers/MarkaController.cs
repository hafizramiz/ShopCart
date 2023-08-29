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

    [MyAuthorization(Roles = "admin")]
    public class MarkaController : Controller
    {
        ShopCartEntities model = new ShopCartEntities();

        // GET: Marka
        [HttpGet]
        public ActionResult Index()
        {
            List<Markalar> markalar=model.Markalars.ToList();
            return View(markalar);
        }


        [MyAuthorization(Roles = "admin")]
        [HttpPost]
        public ActionResult Index(Markalar marka)
        {
            if (marka.markaAdi == null)
            {

                ModelState.AddModelError("", "Gerekli alanlari doldurun");
                return View();
            }
            else
            {
                model.Markalars.AddOrUpdate(marka);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
        }



        [MyAuthorization(Roles = "admin")]
        [HttpPost]
        public void MarkaSil(int id)
        {
            Markalar marka = model.Markalars.FirstOrDefault(x => x.markaId == id);
            if (marka != null)
            {
                model.Markalars.Remove(marka);
                model.SaveChanges();
            }
        }
    }

}