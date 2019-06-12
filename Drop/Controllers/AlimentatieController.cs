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
    public class AlimentatieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Alimentatie
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var today = DateTime.Today;
            var alimentatieDeAzi = db.AportAlimentar.Where(x => x.IdUtilizator == currentUserId && DbFunctions.TruncateTime(x.Data) == today);
            return View(alimentatieDeAzi.ToList());
        }

        // GET: Alimentatie/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Alimentatie/Create
        [HttpPost]
        public ActionResult Add([Bind(Include = "Id,IdUtilizator,Data,IdAliment,Cantitate")] AportAlimentar alimentatie)
        {
            try
            {
                alimentatie.Id = Guid.NewGuid();
                alimentatie.IdUtilizator = User.Identity.GetUserId();
                db.AportAlimentar.Add(alimentatie);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alimentatie/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AportAlimentar alimentatie = db.AportAlimentar.Find(id);
            if (alimentatie == null)
            {
                return HttpNotFound();
            }

            return View(alimentatie);
        }

        // POST: Alimentatie/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,IdUtilizator,Data,IdAliment,Cantitate")] AportAlimentar alimentatie)
        {
            try
            {
                alimentatie.IdUtilizator = User.Identity.GetUserId();

                if (ModelState.IsValid)
                {
                    db.Entry(alimentatie).State = EntityState.Modified;
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

        // GET: Alimentatie/Delete/5
        public ActionResult Delete(Guid id)
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
