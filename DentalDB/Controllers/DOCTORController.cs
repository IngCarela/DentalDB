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
    public class DOCTORController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: DOCTOR
        public ActionResult Index()
        {
            var dOCTOR = db.DOCTOR.Include(d => d.PACIENTE);
            return View(dOCTOR.ToList());
        }

        // GET: DOCTOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR dOCTOR = db.DOCTOR.Find(id);
            if (dOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(dOCTOR);
        }

        // GET: DOCTOR/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre");
            return View();
        }

        // POST: DOCTOR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDoctor,Nombre,IdPaciente")] DOCTOR dOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.DOCTOR.Add(dOCTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", dOCTOR.IdPaciente);
            return View(dOCTOR);
        }

        // GET: DOCTOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR dOCTOR = db.DOCTOR.Find(id);
            if (dOCTOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", dOCTOR.IdPaciente);
            return View(dOCTOR);
        }

        // POST: DOCTOR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDoctor,Nombre,IdPaciente")] DOCTOR dOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", dOCTOR.IdPaciente);
            return View(dOCTOR);
        }

        // GET: DOCTOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR dOCTOR = db.DOCTOR.Find(id);
            if (dOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(dOCTOR);
        }

        // POST: DOCTOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCTOR dOCTOR = db.DOCTOR.Find(id);
            db.DOCTOR.Remove(dOCTOR);
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
