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
        public ActionResult Detay()
        {
            return View();
        }
    }
}