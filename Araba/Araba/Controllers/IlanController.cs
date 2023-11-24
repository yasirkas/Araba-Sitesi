using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Araba.Models;

namespace Araba.Controllers
{
    public class IlanController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Ilan
        public ActionResult Index()
        {
            var ilans = db.Ilans.Include(i => i.Durum).Include(i => i.Model).Include(i => i.Sehir);
            return View(ilans.ToList());
        }

        // GET: Ilan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilans.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // GET: Ilan/Create
        public ActionResult Create()
        {
            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd");
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelAd");
            ViewBag.SehirId = new SelectList(db.Sehirs, "SehirId", "SehirAd");
            return View();
        }

        // POST: Ilan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IlanId,IlanNo,Aciklama,Fiyat,Tarih,Kilometre,ModelYili,YakitTuru,VitesTuru,Username,Telefon,DurumId,MarkaId,ModelId,SehirId")] Ilan ilan)
        {
            if (ModelState.IsValid)
            {
                db.Ilans.Add(ilan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd", ilan.DurumId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelAd", ilan.ModelId);
            ViewBag.SehirId = new SelectList(db.Sehirs, "SehirId", "SehirAd", ilan.SehirId);
            return View(ilan);
        }

        // GET: Ilan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilans.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd", ilan.DurumId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelAd", ilan.ModelId);
            ViewBag.SehirId = new SelectList(db.Sehirs, "SehirId", "SehirAd", ilan.SehirId);
            return View(ilan);
        }

        // POST: Ilan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IlanId,IlanNo,Aciklama,Fiyat,Tarih,Kilometre,ModelYili,YakitTuru,VitesTuru,Username,Telefon,DurumId,MarkaId,ModelId,SehirId")] Ilan ilan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd", ilan.DurumId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "ModelAd", ilan.ModelId);
            ViewBag.SehirId = new SelectList(db.Sehirs, "SehirId", "SehirAd", ilan.SehirId);
            return View(ilan);
        }

        // GET: Ilan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilans.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Ilan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilan ilan = db.Ilans.Find(id);
            db.Ilans.Remove(ilan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
