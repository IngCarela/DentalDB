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
    public class RELACIONTRALAController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: RELACIONTRALA
        public ActionResult Index()
        {
            var rELACIONTRALA = db.RELACIONTRALA.Include(r => r.ESTADOTRABAJO).Include(r => r.LABORATORIO).Include(r => r.TRABAJO);
            return View(rELACIONTRALA.ToList());
        }

        // GET: RELACIONTRALA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RELACIONTRALA rELACIONTRALA = db.RELACIONTRALA.Find(id);
            if (rELACIONTRALA == null)
            {
                return HttpNotFound();
            }
            return View(rELACIONTRALA);
        }

        // GET: RELACIONTRALA/Create
        public ActionResult Create()
        {
            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado");
            ViewBag.IdLaboratorio = new SelectList(db.LABORATORIO, "IdLaboratorio", "Nombre");
            ViewBag.IdTrabajo = new SelectList(db.TRABAJO, "IdTrabajo", "Trabajo1");
            return View();
        }

        // POST: RELACIONTRALA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRelacion,IdTrabajo,IdEstadoT,Fecha,Hora,IdLaboratorio")] RELACIONTRALA rELACIONTRALA)
        {
            if (ModelState.IsValid)
            {
                db.RELACIONTRALA.Add(rELACIONTRALA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado", rELACIONTRALA.IdEstadoT);
            ViewBag.IdLaboratorio = new SelectList(db.LABORATORIO, "IdLaboratorio", "Nombre", rELACIONTRALA.IdLaboratorio);
            ViewBag.IdTrabajo = new SelectList(db.TRABAJO, "IdTrabajo", "Trabajo1", rELACIONTRALA.IdTrabajo);
            return View(rELACIONTRALA);
        }

        // GET: RELACIONTRALA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RELACIONTRALA rELACIONTRALA = db.RELACIONTRALA.Find(id);
            if (rELACIONTRALA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado", rELACIONTRALA.IdEstadoT);
            ViewBag.IdLaboratorio = new SelectList(db.LABORATORIO, "IdLaboratorio", "Nombre", rELACIONTRALA.IdLaboratorio);
            ViewBag.IdTrabajo = new SelectList(db.TRABAJO, "IdTrabajo", "Trabajo1", rELACIONTRALA.IdTrabajo);
            return View(rELACIONTRALA);
        }

        // POST: RELACIONTRALA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRelacion,IdTrabajo,IdEstadoT,Fecha,Hora,IdLaboratorio")] RELACIONTRALA rELACIONTRALA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rELACIONTRALA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado", rELACIONTRALA.IdEstadoT);
            ViewBag.IdLaboratorio = new SelectList(db.LABORATORIO, "IdLaboratorio", "Nombre", rELACIONTRALA.IdLaboratorio);
            ViewBag.IdTrabajo = new SelectList(db.TRABAJO, "IdTrabajo", "Trabajo1", rELACIONTRALA.IdTrabajo);
            return View(rELACIONTRALA);
        }

        // GET: RELACIONTRALA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RELACIONTRALA rELACIONTRALA = db.RELACIONTRALA.Find(id);
            if (rELACIONTRALA == null)
            {
                return HttpNotFound();
            }
            return View(rELACIONTRALA);
        }

        // POST: RELACIONTRALA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RELACIONTRALA rELACIONTRALA = db.RELACIONTRALA.Find(id);
            db.RELACIONTRALA.Remove(rELACIONTRALA);
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
