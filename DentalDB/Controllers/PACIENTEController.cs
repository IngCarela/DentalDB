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
    public class PACIENTEController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: PACIENTE
        public ActionResult Index()
        {
            var pACIENTE = db.PACIENTE.Include(p => p.CENTRO);
            return View(pACIENTE.ToList());
        }

        // GET: PACIENTE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            if (pACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(pACIENTE);
        }

        // GET: PACIENTE/Create
        public ActionResult Create()
        {
            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1");
            return View();
        }

        // POST: PACIENTE/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPaciente,Nombre,Apellido,Direccion,Cedula,Sexo,Edad,Telefono,Estado,Correo,AntecedentesPatologicos,Ocupacion,IdCentro")] PACIENTE pACIENTE)
        {
            if (ModelState.IsValid)
            {
                db.PACIENTE.Add(pACIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1", pACIENTE.IdCentro);
            return View(pACIENTE);
        }

        // GET: PACIENTE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            if (pACIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1", pACIENTE.IdCentro);
            return View(pACIENTE);
        }

        // POST: PACIENTE/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPaciente,Nombre,Apellido,Direccion,Cedula,Sexo,Edad,Telefono,Estado,Correo,AntecedentesPatologicos,Ocupacion,IdCentro")] PACIENTE pACIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pACIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCentro = new SelectList(db.CENTRO, "IdCentro", "Centro1", pACIENTE.IdCentro);
            return View(pACIENTE);
        }

        // GET: PACIENTE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            if (pACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(pACIENTE);
        }

        // POST: PACIENTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            db.PACIENTE.Remove(pACIENTE);
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
