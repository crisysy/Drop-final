using Drop.Models;
using Drop.SqlViews;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Drop.Controllers
{
    public class DonatieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Donatie
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var donatii = db.Donatii.Where(x => x.IdUtilizator == currentUserId);

            return View(donatii.ToList());
        }

        // GET: Donatie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donatie/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,IdUtilizator,Data,Centru,Oras,TipDonatie")] Donatie donatie)
        {
            try
            {
                donatie.Id = Guid.NewGuid();
                donatie.IdUtilizator = User.Identity.GetUserId();
                db.Donatii.Add(donatie);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(donatie);
            }
        }

        // GET: Donatie/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donatie donatie = db.Donatii.Find(id);
            if (donatie == null)
            {
                return HttpNotFound();
            }

            return View(donatie);
        }

        // POST: Donatie/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, [Bind(Include = "Id,IdUtilizator,Data,Centru,Oras,TipDonatie")] Donatie donatie)
        {
            try
            {
                donatie.IdUtilizator = User.Identity.GetUserId();

                if (ModelState.IsValid)
                {
                    db.Entry(donatie).State = EntityState.Modified;
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

        // GET: Donatie/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donatie donatie = db.Donatii.Find(id);
            if (donatie == null)
            {
                return HttpNotFound();
            }

            return View(donatie);
        }

        // POST: Donatie/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Donatie donatie = db.Donatii.Find(id);
                db.Donatii.Remove(donatie);
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
