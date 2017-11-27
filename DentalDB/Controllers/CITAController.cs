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
    public class CITAController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: CITA
        public ActionResult Index()
        {
            var cITA = db.CITA.Include(c => c.CENTRO).Include(c => c.PACIENTE);
            return View(cITA.ToList());
        }

        // GET: CITA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            return View(cITA);
        }

        // GET: CITA/Create
        public ActionResult Create()
        {
            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1");
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre");
            return View();
        }

        // POST: CITA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCita,NumeroCitas,IdPaciente,Fecha,Hora,Descripcion,IdCentro,FuturaCita")] CITA cITA)
        {
            if (ModelState.IsValid)
            {
                db.CITA.Add(cITA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1", cITA.IdCentro);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", cITA.IdPaciente);
            return View(cITA);
        }

        // GET: CITA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1", cITA.IdCentro);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", cITA.IdPaciente);
            return View(cITA);
        }

        // POST: CITA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCita,NumeroCitas,IdPaciente,Fecha,Hora,Descripcion,IdCentro,FuturaCita")] CITA cITA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cITA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1", cITA.IdCentro);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", cITA.IdPaciente);
            return View(cITA);
        }

        // GET: CITA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            return View(cITA);
        }

        // POST: CITA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CITA cITA = db.CITA.Find(id);
            db.CITA.Remove(cITA);
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
