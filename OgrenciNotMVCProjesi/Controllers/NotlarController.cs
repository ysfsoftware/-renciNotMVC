using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVCProjesi.Models.EntityFramework;
using OgrenciNotMVCProjesi.Models;

namespace OgrenciNotMVCProjesi.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        MvcDbOkulEntities db = new MvcDbOkulEntities();
        public ActionResult Index()
        {
            var ntlr = db.TblNotlar.ToList();
            return View(ntlr);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TblNotlar tbn)
        {

            db.TblNotlar.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var notlar = db.TblNotlar.Find(id);
            return View("NotGetir", notlar);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model, TblNotlar p, int Sinav1 = 0, int Sinav2 = 0, int Sinav3 = 0, int Proje = 0)
        {
            if (model.islem == "Hesapla")
            {
                //islem1
                int ortalama = (Sinav1 + Sinav2 + Sinav3 + Proje) / 4;
                ViewBag.ort = ortalama;

            }
            if (model.islem == "NotGüncelle")
            {
                //islem2
                var snv = db.TblNotlar.Find(p.NotID);
                snv.Sinav1 = p.Sinav1;
                snv.Sinav2 = p.Sinav2;
                snv.Sinav3 = p.Sinav3;
                snv.Proje = p.Proje;
                snv.Ortalama = p.Ortalama;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();
        }
    }
}