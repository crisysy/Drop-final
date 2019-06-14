using Drop.Models;
using Drop.SqlViews;
using Drop.ValueObjects;
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
    public class IntervalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Interval
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Profiluri.FirstOrDefault(u => u.IdUtilizator == currentUserId);
            var intervale = db.PerioadeAsteptare.Where(x => x.IdUtilizator == currentUserId);
            if (db.PerioadeAsteptare.Any(x=>x.IdUtilizator == currentUserId))
            {
                return View(intervale.ToList());
            }
            else
            {
                db.PerioadeAsteptare.Add(new PerioadaAsteptare
                {
                    Id = Guid.NewGuid(),
                    IdUtilizator = currentUserId,
                    TipDonatie = TipDonatie.Total,
                    Interval = currentUser.Sex == Sex.Feminin ? 16 : 14
                });
                db.PerioadeAsteptare.Add(new PerioadaAsteptare
                {
                    Id = Guid.NewGuid(),
                    IdUtilizator = currentUserId,
                    TipDonatie = TipDonatie.Plasma,
                    Interval = 2
                });
                db.PerioadeAsteptare.Add(new PerioadaAsteptare
                {
                    Id = Guid.NewGuid(),
                    IdUtilizator = currentUserId,
                    TipDonatie = TipDonatie.Trombocite,
                    Interval = 16
                });
                db.SaveChanges();
            }

            intervale = db.PerioadeAsteptare.Where(x => x.IdUtilizator == currentUserId);
            return View(intervale.ToList());
        }


        // GET: Interval/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerioadaAsteptare interval = db.PerioadeAsteptare.Find(id);
            if (interval == null)
            {
                return HttpNotFound();
            }

            return View(interval);
        }

        // POST: Donatie/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,IdUtilizator,TipDonatie,Interval")] PerioadaAsteptare perioadaAsteptare)
        {
            try
            {
                perioadaAsteptare.IdUtilizator = User.Identity.GetUserId();

                if (ModelState.IsValid)
                {
                    db.Entry(perioadaAsteptare).State = EntityState.Modified;
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

    }
}
