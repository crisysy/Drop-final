using Drop.Models;
using Drop.SqlViews;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Drop.Controllers
{
    public class CerereController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cerere
        public ActionResult Index()
        {
            var cereri = db.Cereri;
            return View(cereri.ToList());
        }

        // GET: Cerere
        public ActionResult Contribuie()
        {
            var cereri = db.Cereri;
            return View(cereri.ToList());
        }
        public ActionResult Contribuit(Guid id)
        {
            try
            {
                Cerere cerere = db.Cereri.Find(id);
                cerere.Contributii = cerere.Contributii + 1;
                db.Entry(cerere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Programare");
            }
            catch
            {
                return RedirectToAction("Contribuie");
            }
        }

        // GET: Cerere/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cerere/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Centru,DataLimita,DonatiiNecesare,Contributii,GrupaSanguinaNecesara")] Cerere cerere)
        {
            try
            {
                cerere.Id = Guid.NewGuid();
                cerere.Contributii = 0;
                db.Cereri.Add(cerere);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cerere);
            }
        }

        // GET: Cerere/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cerere cerere = db.Cereri.Find(id);
            if (cerere == null)
            {
                return HttpNotFound();
            }

            return View(cerere);
        }

        // POST: Donatie/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Centru,DataLimita,DonatiiNecesare,Contributii,GrupaSanguinaNecesara")] Cerere cerere)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(cerere).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: cerere/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                Cerere cerere = db.Cereri.Find(id);
                db.Cereri.Remove(cerere);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
