using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Araba.Models;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;


namespace Araba.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index(int sayfa=1)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var ilan = db.Ilans.Include(m => m.Model).ToList().ToPagedList(sayfa,3);
            return View(ilan);
        }
        public ActionResult MenuFiltre(int id)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var filtre = db.Ilans.Where(i => i.DurumId == id).Include(m => m.Model).Include(m => m.Sehir).Include(m => m.Durum).ToList();

            return View(filtre);
        }

        public ActionResult Filtre(int? min, int? max, int? sehirid, int? durumid, int? markaid, int? modelid)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var filtre = db.Ilans.Where(i => i.Fiyat >= min
             && i.Fiyat <= max
             && i.SehirId == sehirid
             && i.DurumId == durumid
             && i.MarkaId == markaid
             && i.ModelId == modelid).Include(m => m.Model).Include(m => m.Durum).Include(m => m.Sehir).ToList();

            if (min == null && max == null)
            {
                filtre = db.Ilans.Where(i => i.Fiyat >= 0
             && i.Fiyat <= 10000000
             && i.SehirId == sehirid
             && i.DurumId == durumid
             && i.MarkaId == markaid
             && i.ModelId == modelid).Include(m => m.Model).Include(m => m.Durum).Include(m => m.Sehir).ToList();
            }
            if (min != null && max == null)
            {
                filtre = db.Ilans.Where(i => i.Fiyat >= min
             && i.Fiyat <= 10000000
             && i.SehirId == sehirid
             && i.DurumId == durumid
             && i.MarkaId == markaid
             && i.ModelId == modelid).Include(m => m.Model).Include(m => m.Durum).Include(m => m.Sehir).ToList();
            }
            if (max != null && min == null)
            {
                filtre = db.Ilans.Where(i => i.Fiyat >= 0
             && i.Fiyat <= max
             && i.SehirId == sehirid
             && i.DurumId == durumid
             && i.MarkaId == markaid
             && i.ModelId == modelid).Include(m => m.Model).Include(m => m.Durum).Include(m => m.Sehir).ToList();
            }
            if (max == null && min == null && sehirid==null && durumid==null)
            {
                filtre = db.Ilans.Where(i => i.Fiyat >= 0
             && i.Fiyat <= 10000000
             && i.MarkaId == markaid
             && i.ModelId == modelid).Include(m => m.Model).ToList();
            }
            if (max == null && min == null && sehirid != null && durumid == null)
            {
                filtre = db.Ilans.Where(i => i.Fiyat >= 0
             && i.Fiyat <= 10000000
             && i.SehirId == sehirid
             && i.MarkaId == markaid
             && i.ModelId == modelid).Include(m => m.Model).Include(m => m.Sehir).ToList();
            }
            if (max == null && min == null && sehirid == null && durumid != null)
            {
                filtre = db.Ilans.Where(i => i.Fiyat >= 0
             && i.Fiyat <= 10000000
             && i.MarkaId == markaid
             && i.DurumId == durumid
             && i.ModelId == modelid).Include(m => m.Model).Include(m => m.Durum).ToList();
            }
            return View(filtre);
        }
        public PartialViewResult PartialFiltre()
        {
            ViewBag.markalist = new SelectList(MarkaGetir(), "MarkaId", "MarkaAd");
            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd");
            ViewBag.SehirId = new SelectList(db.Sehirs, "SehirId", "SehirAd");
            return PartialView();
        }
        public List<Marka> MarkaGetir()
        {
            List<Marka> markalar = db.Markas.ToList();
            return markalar;
        }
        public ActionResult ModelGetir(int MarkaId)
        {
            List<Model> modellist = db.Models.Where(x => x.MarkaId == MarkaId).ToList();
            ViewBag.modellistesi = new SelectList(modellist, "ModelId", "ModelAd");
            return PartialView("ModelPartial");
        }
        public ActionResult Search(string q)
        {
            var img = db.Resims.ToList();
            ViewBag.imgs = img;
            var ara = db.Ilans.Include(m => m.Model);
            if (!String.IsNullOrEmpty(q))
            {
                ara = ara.Where(i => i.Aciklama.Contains(q) || i.Model.ModelAd.Contains(q) || i.Model.Marka.MarkaAd.ToLower().Contains(q));
                return View(ara.ToList());
            }
            return Redirect(Request.UrlReferrer.PathAndQuery);
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