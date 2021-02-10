using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMVCProjesi.Controllers
{
    public class HesapMakinesiController : Controller
    {
        // GET: HesapMakinesi
        public ActionResult Index(double sayi1 = 0, double sayi2 = 0, double sayi3=0, double sayi4=0, double sayi5=0, double sayi6=0, double sayi7=0, double sayi8=0)
        {
           
            double Topla = sayi1 + sayi2;
            ViewBag.tpl = Topla;

            double Cikar = sayi3 - sayi4;
            ViewBag.ckr = Cikar;

            double Carp = sayi5 * sayi6;
            ViewBag.crp = Carp;

            double Bol = sayi7 / sayi8;
            ViewBag.bol = Bol;


            return View();
        }
       
    }
}