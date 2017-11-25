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
            var lABORATORIO = db.LABORATORIO.Include(l => l.PACIENTE);
            return View(lABORATORIO.ToList());
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
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre");
            return View();
        }

        // POST: LABORATORIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLaboratorio,Fecha,Nombre,IdPaciente")] LABORATORIO lABORATORIO)
        {
            if (ModelState.IsValid)
            {
                db.LABORATORIO.Add(lABORATORIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", lABORATORIO.IdPaciente);
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
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", lABORATORIO.IdPaciente);
            return View(lABORATORIO);
        }

        // POST: LABORATORIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLaboratorio,Fecha,Nombre,IdPaciente")] LABORATORIO lABORATORIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lABORATORIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.PACIENTE, "IdPaciente", "Nombre", lABORATORIO.IdPaciente);
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
