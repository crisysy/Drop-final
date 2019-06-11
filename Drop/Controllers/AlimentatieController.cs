using Drop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        // GET: Alimentatie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alimentatie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alimentatie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alimentatie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alimentatie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alimentatie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alimentatie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

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
