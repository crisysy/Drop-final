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

        
        public ActionResult Index()
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
            } else
            {
                userinfo.Id = Guid.NewGuid();
                userinfo.IdUtilizator = currentUserId;
            }


            return View(userinfo);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = ("Id,IdUtilizator,Nume,Prenume,Oras,Sex,Greutate,Inaltime,GrupaSanguina,Rh"))] Profil profil)
        {

            profil.IdUtilizator = User.Identity.GetUserId();

            if (db.Profiluri.Any(x => x.Id == profil.Id))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(profil).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Edit");
                }
            } else
            {
                db.Profiluri.Add(profil);
                db.SaveChanges();
                return RedirectToAction("Edit");
            }



            //if (ModelState.IsValid)
            //{
            //    db.Entry(profil).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //var currentUserId = User.Identity.GetUserId();
            //var currentUser = db.Users.FirstOrDefault(u => u.Id == currentUserId);
            //var userinfo = new ProfilViewModel
            //{
            //    Id = currentUserId,
            //    Nume = currentUser.Nume,
            //    Prenume = currentUser.Prenume,
            //    Oras = currentUser.Oras,
            //    Sex = currentUser.Sex,
            //    Greutate = currentUser.Greutate,
            //    Inaltime = currentUser.Inaltime,
            //    GrupaSanguina = currentUser.GrupaSanguina,
            //    Rh = currentUser.Rh
            //};

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
