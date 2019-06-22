using Drop.Models;
using Drop.ValueObjects;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drop.Controllers
{
    public class ProgramareController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Programare
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var profil = db.Profiluri.First(x => x.IdUtilizator == currentUserId);
            var currentUser = db.Users.FirstOrDefault(u => u.Id == currentUserId);
            var ultimaDonatie = db.Donatii.Where(x => x.IdUtilizator == currentUserId).OrderByDescending(x => x.Data).First();
            DateTime dataUrmatoareiDonatii;
            TipDonatie tipDonatie;
            int interval = 16;
            if (ultimaDonatie == null)
            {
                dataUrmatoareiDonatii = DateTime.Today;
            }
            else
            {
                tipDonatie = ultimaDonatie.TipDonatie;
                var existaInterval = db.PerioadeAsteptare.First(x => x.IdUtilizator == currentUserId && x.TipDonatie == tipDonatie);
                interval = existaInterval != null ? existaInterval.Interval : 16;
                dataUrmatoareiDonatii = ultimaDonatie.Data.AddDays(interval * 7);
            }
            var zileRamase = DateTime.Today.Date < dataUrmatoareiDonatii.Date ? (dataUrmatoareiDonatii.Date - DateTime.Today.Date).Days : 0;
            ViewBag.total = interval * 7;
            ViewBag.left = zileRamase;
            var progres = interval * 7 - zileRamase;
            ViewBag.progres = (progres * 100) / (interval * 7);
            ViewBag.data = dataUrmatoareiDonatii;
            ViewBag.sex = profil.Sex;
            ViewBag.oras = profil.Oras;
            return View();
        }

    }
}
