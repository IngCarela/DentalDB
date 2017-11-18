using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DentalDB.Models;

namespace DentalDB.Controllers
{
    public class CENTROesController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: CENTROes
        public ActionResult Index()
        {
            return View(db.CENTRO.ToList());
        }

        // GET: CENTROes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTRO cENTRO = db.CENTRO.Find(id);
            if (cENTRO == null)
            {
                return HttpNotFound();
            }
            return View(cENTRO);
        }

        // GET: CENTROes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CENTROes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCentro,Centro1,Lugar")] CENTRO cENTRO)
        {
            if (ModelState.IsValid)
            {
                db.CENTRO.Add(cENTRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cENTRO);
        }

        // GET: CENTROes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTRO cENTRO = db.CENTRO.Find(id);
            if (cENTRO == null)
            {
                return HttpNotFound();
            }
            return View(cENTRO);
        }

        // POST: CENTROes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCentro,Centro1,Lugar")] CENTRO cENTRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cENTRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cENTRO);
        }

        // GET: CENTROes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTRO cENTRO = db.CENTRO.Find(id);
            if (cENTRO == null)
            {
                return HttpNotFound();
            }
            return View(cENTRO);
        }

        // POST: CENTROes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CENTRO cENTRO = db.CENTRO.Find(id);
            db.CENTRO.Remove(cENTRO);
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
