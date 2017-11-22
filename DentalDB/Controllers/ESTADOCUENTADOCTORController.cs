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
    public class ESTADOCUENTADOCTORController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: ESTADOCUENTADOCTOR
        public ActionResult Index()
        {
            var eSTADOCUENTADOCTOR = db.ESTADOCUENTADOCTOR.Include(e => e.DOCTOR).Include(e => e.PACIENTE);
            return View(eSTADOCUENTADOCTOR.ToList());
        }

        // GET: ESTADOCUENTADOCTOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCUENTADOCTOR eSTADOCUENTADOCTOR = db.ESTADOCUENTADOCTOR.Find(id);
            if (eSTADOCUENTADOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOCUENTADOCTOR);
        }

        // GET: ESTADOCUENTADOCTOR/Create
        public ActionResult Create()
        {
            ViewBag.IdDoctor = new SelectList(db.DOCTOR, "IdDoctor", "Nombre");
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre");
            return View();
        }

        // POST: ESTADOCUENTADOCTOR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstadoD,Fecha,IdDoctor,IdPaciente,Monto,Abono,Faltante")] ESTADOCUENTADOCTOR eSTADOCUENTADOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.ESTADOCUENTADOCTOR.Add(eSTADOCUENTADOCTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDoctor = new SelectList(db.DOCTOR, "IdDoctor", "Nombre", eSTADOCUENTADOCTOR.IdDoctor);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", eSTADOCUENTADOCTOR.IdPaciente);
            return View(eSTADOCUENTADOCTOR);
        }

        // GET: ESTADOCUENTADOCTOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCUENTADOCTOR eSTADOCUENTADOCTOR = db.ESTADOCUENTADOCTOR.Find(id);
            if (eSTADOCUENTADOCTOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDoctor = new SelectList(db.DOCTOR, "IdDoctor", "Nombre", eSTADOCUENTADOCTOR.IdDoctor);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", eSTADOCUENTADOCTOR.IdPaciente);
            return View(eSTADOCUENTADOCTOR);
        }

        // POST: ESTADOCUENTADOCTOR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstadoD,Fecha,IdDoctor,IdPaciente,Monto,Abono,Faltante")] ESTADOCUENTADOCTOR eSTADOCUENTADOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADOCUENTADOCTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDoctor = new SelectList(db.DOCTOR, "IdDoctor", "Nombre", eSTADOCUENTADOCTOR.IdDoctor);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", eSTADOCUENTADOCTOR.IdPaciente);
            return View(eSTADOCUENTADOCTOR);
        }

        // GET: ESTADOCUENTADOCTOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCUENTADOCTOR eSTADOCUENTADOCTOR = db.ESTADOCUENTADOCTOR.Find(id);
            if (eSTADOCUENTADOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOCUENTADOCTOR);
        }

        // POST: ESTADOCUENTADOCTOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADOCUENTADOCTOR eSTADOCUENTADOCTOR = db.ESTADOCUENTADOCTOR.Find(id);
            db.ESTADOCUENTADOCTOR.Remove(eSTADOCUENTADOCTOR);
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
