using Araba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Araba.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IlanListesi()
        {
            var ilan = db.Ilans.Include(i => i.Model).Include(i => i.Durum).Include(i => i.Sehir).ToList();
            return View(ilan);
        }
    }
}