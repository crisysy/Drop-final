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
    public class ProfilController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        public ActionResult Succes()
        {
            return View();
        }

        public ActionResult Edit()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.FirstOrDefault(u => u.Id == currentUserId);
            var userinfo = new Profil();

            if (db.Profiluri.Any(x => x.IdUtilizator == currentUserId))
            {
                var profil = db.Profiluri.FirstOrDefault(p => p.IdUtilizator == currentUserId);
                userinfo.Id = profil.Id;
                userinfo.IdUtilizator = currentUserId;
                userinfo.Nume = profil.Nume;
                userinfo.Prenume = profil.Prenume;
                userinfo.Oras = profil.Oras;
                userinfo.Sex = profil.Sex;
                userinfo.Greutate = profil.Greutate;
                userinfo.Inaltime = profil.Inaltime;
                userinfo.GrupaSanguina = profil.GrupaSanguina;
                userinfo.Rh = profil.Rh;
                userinfo.StilDeViata = profil.StilDeViata;
            } else
            {
                userinfo.Id = Guid.NewGuid();
                userinfo.IdUtilizator = currentUserId;
            }


            return View(userinfo);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = ("Id,IdUtilizator,Nume,Prenume,Oras,Sex,Greutate,Inaltime,GrupaSanguina,Rh,StilDeViata"))] Profil profil)
        {

            profil.IdUtilizator = User.Identity.GetUserId();

            if (db.Profiluri.Any(x => x.Id == profil.Id))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(profil).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Succes");
                }
            } else
            {
                db.Profiluri.Add(profil);
                db.SaveChanges();
                return RedirectToAction("Succes");
            }

            return View(profil);
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
