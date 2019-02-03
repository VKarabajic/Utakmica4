using Rotativa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utamica4.Models;

namespace Utamica4.Controllers
{
    public class NatjecanjesController : Controller
    {
        private UtakmicaDBEntities db = new UtakmicaDBEntities();

        // GET: Natjecanjes
        public ActionResult Index()
        {
            return View(db.Natjecanjes.ToList());
        }

        public ActionResult KonRez()
        {
            return View("KonRez" ,db.Natjecanjes.ToList());
        }

        /*************************PDF*********************************/
        public ActionResult IndexPDF()
        {
            using (UtakmicaDBEntities db = new UtakmicaDBEntities())
            {
                var utakmicalist = db.Natjecanjes.ToList();

                return View(utakmicalist);
            }
        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("IndexPDF");
            return report;
        }

        public ActionResult PrintPartialViewToPdf(int id)
        {
            using (UtakmicaDBEntities db = new UtakmicaDBEntities())
            {
                Natjecanje natj = db.Natjecanjes.FirstOrDefault(n => n.Id == id);

                var report = new PartialViewAsPdf("~/Views/Natjecanjes/DetaljiPDF.cshtml", natj);
                return report;
            }

        }

        /***********detalji bez rezultata*******************/
        // GET: Natjecanjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Natjecanje natjecanje = db.Natjecanjes.Find(id);
            if (natjecanje == null)
            {
                return HttpNotFound();
            }
            return View(natjecanje);
        }

        /************detalji sa rezultatom***************/

        public ActionResult DetailsSa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Natjecanje natjecanje = db.Natjecanjes.Find(id);
            if (natjecanje == null)
            {
                return HttpNotFound();
            }
            return View(natjecanje);
        }



        /*************Dodavanje utakmice sa rezultatima**********/
        // GET: Natjecanjes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Natjecanjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NazivUtakmice,Ekipa1,Ekipa2,Raspored,RezultatE1, RezultatE2")] Natjecanje natjecanje)
        {
            if (ModelState.IsValid)
            {
                db.Natjecanjes.Add(natjecanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(natjecanje);
        }

        /****************************Dodaj utakmicu****************///

        public ActionResult CreateUt()
        {
            return View();
        }

        // POST: Natjecanjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUt([Bind(Include = "Id,NazivUtakmice,Ekipa1,Ekipa2,Raspored")] Natjecanje natjecanje)
        {
            if (ModelState.IsValid)
            {
                db.Natjecanjes.Add(natjecanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(natjecanje);
        }

        /*************************EDIT S REZULTATIMA*************************/
        // GET: Natjecanjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Natjecanje natjecanje = db.Natjecanjes.Find(id);
            if (natjecanje == null)
            {
                return HttpNotFound();
            }
            return View(natjecanje);
        }

        // POST: Natjecanjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NazivUtakmice,Ekipa1,Ekipa2,Raspored,RezultatE1, RezultatE2")] Natjecanje natjecanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(natjecanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(natjecanje);
        }


        /*************************EDIT BEZ REZULTATA*************************/
        public ActionResult EditBez(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Natjecanje natjecanje = db.Natjecanjes.Find(id);
            if (natjecanje == null)
            {
                return HttpNotFound();
            }
            return View(natjecanje);
        }

        // POST: Natjecanjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBez([Bind(Include = "Id,NazivUtakmice,Ekipa1,Ekipa2,Raspored")] Natjecanje natjecanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(natjecanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(natjecanje);
        }



        // GET: Natjecanjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Natjecanje natjecanje = db.Natjecanjes.Find(id);
            if (natjecanje == null)
            {
                return HttpNotFound();
            }
            return View(natjecanje);
        }

        // POST: Natjecanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Natjecanje natjecanje = db.Natjecanjes.Find(id);
            db.Natjecanjes.Remove(natjecanje);
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
