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
    public class ESTADOCUENTACENTROController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: ESTADOCUENTACENTRO
        public ActionResult Index()
        {
            var eSTADOCUENTACENTRO = db.ESTADOCUENTACENTRO.Include(e => e.CENTRO).Include(e => e.PACIENTE);
            return View(eSTADOCUENTACENTRO.ToList());
        }

        // GET: ESTADOCUENTACENTRO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCUENTACENTRO eSTADOCUENTACENTRO = db.ESTADOCUENTACENTRO.Find(id);
            if (eSTADOCUENTACENTRO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOCUENTACENTRO);
        }

        // GET: ESTADOCUENTACENTRO/Create
        public ActionResult Create()
        {
            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1");
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre");
            return View();
        }

        // POST: ESTADOCUENTACENTRO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstadoD,Fecha,IdCentro,IdPaciente,Monto,Abono,Faltante")] ESTADOCUENTACENTRO eSTADOCUENTACENTRO)
        {
            if (ModelState.IsValid)
            {
                db.ESTADOCUENTACENTRO.Add(eSTADOCUENTACENTRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1", eSTADOCUENTACENTRO.IdCentro);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", eSTADOCUENTACENTRO.IdPaciente);
            return View(eSTADOCUENTACENTRO);
        }

        // GET: ESTADOCUENTACENTRO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCUENTACENTRO eSTADOCUENTACENTRO = db.ESTADOCUENTACENTRO.Find(id);
            if (eSTADOCUENTACENTRO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1", eSTADOCUENTACENTRO.IdCentro);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", eSTADOCUENTACENTRO.IdPaciente);
            return View(eSTADOCUENTACENTRO);
        }

        // POST: ESTADOCUENTACENTRO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstadoD,Fecha,IdCentro,IdPaciente,Monto,Abono,Faltante")] ESTADOCUENTACENTRO eSTADOCUENTACENTRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADOCUENTACENTRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1", eSTADOCUENTACENTRO.IdCentro);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", eSTADOCUENTACENTRO.IdPaciente);
            return View(eSTADOCUENTACENTRO);
        }

        // GET: ESTADOCUENTACENTRO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCUENTACENTRO eSTADOCUENTACENTRO = db.ESTADOCUENTACENTRO.Find(id);
            if (eSTADOCUENTACENTRO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOCUENTACENTRO);
        }

        // POST: ESTADOCUENTACENTRO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADOCUENTACENTRO eSTADOCUENTACENTRO = db.ESTADOCUENTACENTRO.Find(id);
            db.ESTADOCUENTACENTRO.Remove(eSTADOCUENTACENTRO);
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
