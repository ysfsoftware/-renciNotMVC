using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using OgrenciNotMVCProjesi.Models.EntityFramework;

namespace OgrenciNotMVCProjesi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        MvcDbOkulEntities db = new MvcDbOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.TblDersler.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TblDersler drs)
        {
            db.TblDersler.Add(drs);
            db.SaveChanges();
            MessageBox.Show("Ders Ekleme İşlemi Başarıyla Gerçekleştirildi.");
            return View();
            
        }
        public ActionResult Sil(int id)
        {
            var ders = db.TblDersler.Find(id);
            db.TblDersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders2 = db.TblDersler.Find(id);

            return View("DersGetir",ders2);
        }
        public ActionResult Güncelle(TblDersler p)
        {
            var drs = db.TblDersler.Find(p.DersID);
            drs.DersAd = p.DersAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}