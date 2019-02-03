using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utamica4.Models;

namespace Utamica4.Controllers
{
    public class HomeController : Controller
    {

        private UtakmicaDBEntities db = new UtakmicaDBEntities();

        public ActionResult Index()
        {
            return View(db.Natjecanjes.ToList());
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ovo je projekt iz Predmeta Programski alati u programiranju.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Izradila: Vanda Karabajić";
               
            return View();
        }
    }
}