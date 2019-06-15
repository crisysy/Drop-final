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
    public class AlimentatieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Alimentatie
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.FirstOrDefault(u => u.Id == currentUserId);
            var profil = db.Profiluri.First(x => x.IdUtilizator == currentUserId);
            var today = DateTime.Today;
            var alimentatieDeAzi = db.AportAlimentar.Where(x => x.IdUtilizator == currentUserId && DbFunctions.TruncateTime(x.Data) == today);

            decimal calorii = 0;
            decimal proteine = 0;
            decimal grasimi = 0;
            decimal carbohidrati = 0;
            decimal fier = 0;
            decimal acidFolic = 0;
            decimal b2 = 0;
            decimal b6 = 0;
            decimal vitC = 0;

            foreach (var aliment in alimentatieDeAzi)
            {
                calorii = calorii + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).ValoareEnergetica/100;
                proteine = proteine + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Proteine/100;
                grasimi = grasimi + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Glucide/100;
                carbohidrati = carbohidrati + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Carbohidrati/100;
                fier = fier + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Fier/100;
                acidFolic = acidFolic + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).AcidFolic/100;
                b2 = b2 + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Riboflavina/100;
                b6 = b6 + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Piridoxina/100;
                vitC = vitC + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).VitaminaC/100;
            }
            decimal indiceStilDeViata = 1.55m;
            switch (profil.StilDeViata)
            {
                case StilViata.Sedentar:
                    indiceStilDeViata = 1.2m;
                    break;
                case StilViata.PutinActiv:
                    indiceStilDeViata = 1.37m;
                    break;
                case StilViata.Moderat:
                    indiceStilDeViata = 1.55m;
                    break;
                case StilViata.Activ:
                    indiceStilDeViata = 1.72m;
                    break;
                case StilViata.FoarteActiv:
                    indiceStilDeViata = 1.9m;
                    break;
            }
            var age = today.Year - currentUser.DataNasterii.Year;

            var aportCaloricNecesar = profil.Sex == Sex.Feminin ? (655.1m + (9.563m * profil.Greutate) + (1.85m * profil.Inaltime) - (4.676m * age) - 161)*indiceStilDeViata : (66.47m + (13.75m * profil.Greutate) + (5.003m * profil.Inaltime) - (6.755m * age) + 5)*indiceStilDeViata;
            ViewBag.progrescaloric = calorii * 100 / aportCaloricNecesar;
            ViewBag.progresproteine = proteine * 100 / 45;
            ViewBag.progresgrasimi = grasimi * 100 / 65;
            ViewBag.progrescarbohidrati = carbohidrati * 100 / 130;
            ViewBag.progresfier = fier * 100 / 15;
            ViewBag.progresAcidFolic = acidFolic * 100 / 400;
            ViewBag.progresB2 = b2 * 100 ;
            ViewBag.progresB6 = b6 * 100 / 1.2m;
            ViewBag.progresVitC = vitC * 100 / 65;



            return View(alimentatieDeAzi.ToList());
        }

        public ActionResult Istoric()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.FirstOrDefault(u => u.Id == currentUserId);
            var profil = db.Profiluri.First(x => x.IdUtilizator == currentUserId);
            var today = DateTime.Today;
            var yesterday = DateTime.Today.AddDays(-1); 
            var alimentatieDeAzi = db.AportAlimentar.Where(x => x.IdUtilizator == currentUserId && DbFunctions.TruncateTime(x.Data) == yesterday);
            decimal calorii = 0;
            decimal proteine = 0;
            decimal grasimi = 0;
            decimal carbohidrati = 0;
            decimal fier = 0;
            decimal acidFolic = 0;
            decimal b2 = 0;
            decimal b6 = 0;
            decimal vitC = 0;
            foreach (var aliment in alimentatieDeAzi)
            {
                calorii = calorii + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).ValoareEnergetica / 100;
                proteine = proteine + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Proteine / 100;
                grasimi = grasimi + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Glucide / 100;
                carbohidrati = carbohidrati + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Carbohidrati / 100;
                fier = fier + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Fier / 100;
                acidFolic = acidFolic + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).AcidFolic / 100;
                b2 = b2 + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Riboflavina / 100;
                b6 = b6 + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).Piridoxina / 100;
                vitC = vitC + aliment.Cantitate * db.Alimente.First(x => x.Id == aliment.IdAliment).VitaminaC / 100;
            }
            decimal indiceStilDeViata = 1.55m;
            switch (profil.StilDeViata)
            {
                case StilViata.Sedentar:
                    indiceStilDeViata = 1.2m;
                    break;
                case StilViata.PutinActiv:
                    indiceStilDeViata = 1.37m;
                    break;
                case StilViata.Moderat:
                    indiceStilDeViata = 1.55m;
                    break;
                case StilViata.Activ:
                    indiceStilDeViata = 1.72m;
                    break;
                case StilViata.FoarteActiv:
                    indiceStilDeViata = 1.9m;
                    break;
            }
            var age = today.Year - currentUser.DataNasterii.Year;

            var aportCaloricNecesar = profil.Sex == Sex.Feminin ? (655.1m + (9.563m * profil.Greutate) + (1.85m * profil.Inaltime) - (4.676m * age)) * indiceStilDeViata : (66.47m + (13.75m * profil.Greutate) + (5.003m * profil.Inaltime) - (6.755m * age)) * indiceStilDeViata;

            ViewBag.progrescaloric = calorii * 100 / aportCaloricNecesar;
            ViewBag.progresproteine = proteine * 100 / 45;
            ViewBag.progresgrasimi = grasimi * 100 / 65;
            ViewBag.progrescarbohidrati = carbohidrati * 100 / 130;
            ViewBag.progresfier = fier * 100 / 15;
            ViewBag.progresAcidFolic = acidFolic * 100 / 400;
            ViewBag.progresB2 = b2 * 100;
            ViewBag.progresB6 = b6 * 100 / 1.2m;
            ViewBag.progresVitC = vitC * 100 / 65;

            return View(alimentatieDeAzi.ToList());
        }

        // GET: Alimentatie/Create
        public ActionResult Create()
        {
            ViewBag.IdAliment = new SelectList(db.Alimente, "Id", "Nume");
            return View();
        }

        // POST: Alimentatie/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,IdUtilizator,Data,IdAliment,Cantitate")] AportAlimentar alimentatie)
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
                ViewBag.IdAliment = new SelectList(db.Alimente, "Id", "Nume", alimentatie.IdAliment);
                return View(alimentatie);
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
        public ActionResult Edit([Bind(Include = "Id,IdUtilizator,IdAliment,Data,Cantitate")] AportAlimentar alimentatie)
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
                AportAlimentar aliment = db.AportAlimentar.Find(id);
                db.AportAlimentar.Remove(aliment);
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
