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
    public class LABORATORIOController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: LABORATORIO
        public ActionResult Index()
        {
            return View(db.LABORATORIO.ToList());
        }

        // GET: LABORATORIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LABORATORIO lABORATORIO = db.LABORATORIO.Find(id);
            if (lABORATORIO == null)
            {
                return HttpNotFound();
            }
            return View(lABORATORIO);
        }

        // GET: LABORATORIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LABORATORIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLaboratorio,Nombre,Fecha,Hora")] LABORATORIO lABORATORIO)
        {
            if (ModelState.IsValid)
            {
                db.LABORATORIO.Add(lABORATORIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lABORATORIO);
        }

        // GET: LABORATORIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LABORATORIO lABORATORIO = db.LABORATORIO.Find(id);
            if (lABORATORIO == null)
            {
                return HttpNotFound();
            }
            return View(lABORATORIO);
        }

        // POST: LABORATORIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLaboratorio,Nombre,Fecha,Hora")] LABORATORIO lABORATORIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lABORATORIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lABORATORIO);
        }

        // GET: LABORATORIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LABORATORIO lABORATORIO = db.LABORATORIO.Find(id);
            if (lABORATORIO == null)
            {
                return HttpNotFound();
            }
            return View(lABORATORIO);
        }

        // POST: LABORATORIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LABORATORIO lABORATORIO = db.LABORATORIO.Find(id);
            db.LABORATORIO.Remove(lABORATORIO);
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
