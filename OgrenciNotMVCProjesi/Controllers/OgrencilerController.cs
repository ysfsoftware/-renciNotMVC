using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using OgrenciNotMVCProjesi.Models.EntityFramework;

namespace OgrenciNotMVCProjesi.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        MvcDbOkulEntities db = new MvcDbOkulEntities();
        public ActionResult Index()
        {
            var ogrlr = db.TblOgrenciler.ToList();
            return View(ogrlr);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TblKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TblOgrenciler ogr)
        {
            var klp = db.TblKulupler.Where(m => m.KulupID == ogr.TblKulupler.KulupID).FirstOrDefault();
            ogr.TblKulupler = klp;
            db.TblOgrenciler.Add(ogr);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Ekleme İşlemi Başarıyla Gerçekleştirildi.");
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TblOgrenciler.Find(id);
            db.TblOgrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci2 = db.TblOgrenciler.Find(id);

            List<SelectListItem> degerler = (from i in db.TblKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("OgrenciGetir", ogrenci2);
        }
        public ActionResult Güncelle(TblOgrenciler p)
        {
            var ogr = db.TblOgrenciler.Find(p.OgrenciID);
            ogr.OgrenciAd = p.OgrenciAd;
            ogr.OgrenciSoyad = p.OgrenciSoyad;
            ogr.OgrenciFotograf = p.OgrenciFotograf;
            ogr.OgrenciCinsiyet = p.OgrenciCinsiyet;
            ogr.OgrenciKulup = p.OgrenciKulup;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenciler");
        }
    }
}