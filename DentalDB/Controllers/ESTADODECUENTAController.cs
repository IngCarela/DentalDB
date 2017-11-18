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
    public class ESTADODECUENTAController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: ESTADODECUENTA
        public ActionResult Index()
        {
            var eSTADODECUENTA = db.ESTADODECUENTA.Include(e => e.PACIENTE);
            return View(eSTADODECUENTA.ToList());
        }

        // GET: ESTADODECUENTA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADODECUENTA eSTADODECUENTA = db.ESTADODECUENTA.Find(id);
            if (eSTADODECUENTA == null)
            {
                return HttpNotFound();
            }
            return View(eSTADODECUENTA);
        }

        // GET: ESTADODECUENTA/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre");
            return View();
        }

        // POST: ESTADODECUENTA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstadoP,Monto,Abono,Faltante,IdPaciente")] ESTADODECUENTA eSTADODECUENTA)
        {
            if (ModelState.IsValid)
            {
                db.ESTADODECUENTA.Add(eSTADODECUENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", eSTADODECUENTA.IdPaciente);
            return View(eSTADODECUENTA);
        }

        // GET: ESTADODECUENTA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADODECUENTA eSTADODECUENTA = db.ESTADODECUENTA.Find(id);
            if (eSTADODECUENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", eSTADODECUENTA.IdPaciente);
            return View(eSTADODECUENTA);
        }

        // POST: ESTADODECUENTA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstadoP,Monto,Abono,Faltante,IdPaciente")] ESTADODECUENTA eSTADODECUENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADODECUENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", eSTADODECUENTA.IdPaciente);
            return View(eSTADODECUENTA);
        }

        // GET: ESTADODECUENTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADODECUENTA eSTADODECUENTA = db.ESTADODECUENTA.Find(id);
            if (eSTADODECUENTA == null)
            {
                return HttpNotFound();
            }
            return View(eSTADODECUENTA);
        }

        // POST: ESTADODECUENTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADODECUENTA eSTADODECUENTA = db.ESTADODECUENTA.Find(id);
            db.ESTADODECUENTA.Remove(eSTADODECUENTA);
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
