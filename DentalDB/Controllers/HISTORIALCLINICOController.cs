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
    public class HISTORIALCLINICOController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: HISTORIALCLINICO
        public ActionResult Index()
        {
            var hISTORIALCLINICO = db.HISTORIALCLINICO.Include(h => h.PACIENTE).Include(h => h.TRABAJO);
            return View(hISTORIALCLINICO.ToList());
        }

        // GET: HISTORIALCLINICO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIALCLINICO hISTORIALCLINICO = db.HISTORIALCLINICO.Find(id);
            if (hISTORIALCLINICO == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIALCLINICO);
        }

        // GET: HISTORIALCLINICO/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre");
            ViewBag.IdTrabajo = new SelectList(db.TRABAJO, "IdTrabajo", "Tratamiento");
            return View();
        }

        // POST: HISTORIALCLINICO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHistorial,IdPaciente,IdTrabajo,Descripcion")] HISTORIALCLINICO hISTORIALCLINICO)
        {
            if (ModelState.IsValid)
            {
                db.HISTORIALCLINICO.Add(hISTORIALCLINICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", hISTORIALCLINICO.IdPaciente);
            ViewBag.IdTrabajo = new SelectList(db.TRABAJO, "IdTrabajo", "Tratamiento", hISTORIALCLINICO.IdTrabajo);
            return View(hISTORIALCLINICO);
        }

        // GET: HISTORIALCLINICO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIALCLINICO hISTORIALCLINICO = db.HISTORIALCLINICO.Find(id);
            if (hISTORIALCLINICO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", hISTORIALCLINICO.IdPaciente);
            ViewBag.IdTrabajo = new SelectList(db.TRABAJO, "IdTrabajo", "Tratamiento", hISTORIALCLINICO.IdTrabajo);
            return View(hISTORIALCLINICO);
        }

        // POST: HISTORIALCLINICO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHistorial,IdPaciente,IdTrabajo,Descripcion")] HISTORIALCLINICO hISTORIALCLINICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hISTORIALCLINICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", hISTORIALCLINICO.IdPaciente);
            ViewBag.IdTrabajo = new SelectList(db.TRABAJO, "IdTrabajo", "Tratamiento", hISTORIALCLINICO.IdTrabajo);
            return View(hISTORIALCLINICO);
        }

        // GET: HISTORIALCLINICO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIALCLINICO hISTORIALCLINICO = db.HISTORIALCLINICO.Find(id);
            if (hISTORIALCLINICO == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIALCLINICO);
        }

        // POST: HISTORIALCLINICO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HISTORIALCLINICO hISTORIALCLINICO = db.HISTORIALCLINICO.Find(id);
            db.HISTORIALCLINICO.Remove(hISTORIALCLINICO);
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
