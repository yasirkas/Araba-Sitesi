using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Araba.Models;
using System.Data.Entity;


namespace Araba.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var ilan = db.Ilans.Include(m => m.Model).ToList();
            return View(ilan);
        }
        public ActionResult Detay(int id)
        {
            var ilan = db.Ilans.Where(i => i.IlanId == id).Include(m => m.Model).Include(m => m.Durum).Include(m => m.Sehir).Include(m => m.Model).FirstOrDefault();
            var imgs = db.Resims.Where(i => i.IlanId == id).ToList();
            ViewBag.imgs = imgs;
            return View(ilan);
        }
        public PartialViewResult Slider()
        {
            var ilan = db.Ilans.ToList().Take(5);
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            return PartialView(ilan);
        }
    }
}