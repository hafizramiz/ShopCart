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
    public class UlkeController : Controller
    {
        ShopCartEntities model = new ShopCartEntities();

        // GET: Marka
        [HttpGet]
        public ActionResult Index()
        {
            List<Bolgeler> bolgeler = model.Bolgelers.ToList();
            return View(bolgeler);
        }


        [MyAuthorization(Roles = "admin")]
        [HttpPost]
        public ActionResult Index(Bolgeler bolge)
        {
            if (bolge.bolgeTanimi == null)
            {

                ModelState.AddModelError("", "Gerekli alanlari doldurun");
                return View();
            }
            else
            {
                model.Bolgelers.AddOrUpdate(bolge);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
        }



        [MyAuthorization(Roles="admin")]
        [HttpPost]

        public int BolgeSil(int id)
        {
            Bolgeler b = model.Bolgelers.FirstOrDefault(x => x.bolgeId == id);
            try
            {
                model.Bolgelers.Remove(b);
                model.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }

    }
}