using OgrenciNotMVCProjesi.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace OgrenciNotMVCProjesi.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        MvcDbOkulEntities db = new MvcDbOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TblKulupler.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TblKulupler klp)
        {
            db.TblKulupler.Add(klp);
            db.SaveChanges();
            MessageBox.Show("Kulüp Ekleme İşlemi Başarıyla Gerçekleştirildi.");
            return View();

        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TblKulupler.Find(id);
            db.TblKulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var kulup2 = db.TblKulupler.Find(id);
           
            return View("KulupGetir",kulup2);
        }
        public ActionResult Guncelle(TblKulupler p)
        {
            var klp = db.TblKulupler.Find(p.KulupID);
            klp.KulupAd = p.KulupAd;
            db.SaveChanges();
            return RedirectToAction("Index","Kulupler");

        }
    }
}