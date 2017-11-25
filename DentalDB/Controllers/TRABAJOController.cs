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
    public class TRABAJOController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: TRABAJO
        public ActionResult Index()
        {
            var tRABAJO = db.TRABAJO.Include(t => t.ESTADOTRABAJO).Include(t => t.ESTADOTRABAJO1).Include(t => t.PACIENTE);
            return View(tRABAJO.ToList());
        }

        // GET: TRABAJO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRABAJO tRABAJO = db.TRABAJO.Find(id);
            if (tRABAJO == null)
            {
                return HttpNotFound();
            }
            return View(tRABAJO);
        }

        // GET: TRABAJO/Create
        public ActionResult Create()
        {
            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado");
            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado");
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre");
            return View();
        }

        // POST: TRABAJO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTrabajo,Tratamiento,Monto,IdPaciente,Fecha,Hora,IdEstadoT,Descripcion")] TRABAJO tRABAJO)
        {
            if (ModelState.IsValid)
            {
                db.TRABAJO.Add(tRABAJO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado", tRABAJO.IdEstadoT);
            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado", tRABAJO.IdEstadoT);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", tRABAJO.IdPaciente);
            return View(tRABAJO);
        }

        // GET: TRABAJO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRABAJO tRABAJO = db.TRABAJO.Find(id);
            if (tRABAJO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado", tRABAJO.IdEstadoT);
            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado", tRABAJO.IdEstadoT);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", tRABAJO.IdPaciente);
            return View(tRABAJO);
        }

        // POST: TRABAJO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTrabajo,Tratamiento,Monto,IdPaciente,Fecha,Hora,IdEstadoT,Descripcion")] TRABAJO tRABAJO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRABAJO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado", tRABAJO.IdEstadoT);
            ViewBag.IdEstadoT = new SelectList(db.ESTADOTRABAJO, "IdEstadoT", "Estado", tRABAJO.IdEstadoT);
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", tRABAJO.IdPaciente);
            return View(tRABAJO);
        }

        // GET: TRABAJO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRABAJO tRABAJO = db.TRABAJO.Find(id);
            if (tRABAJO == null)
            {
                return HttpNotFound();
            }
            return View(tRABAJO);
        }

        // POST: TRABAJO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRABAJO tRABAJO = db.TRABAJO.Find(id);
            db.TRABAJO.Remove(tRABAJO);
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
