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
    public class ESTADOCUENTALABORATORIOsController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: ESTADOCUENTALABORATORIOs
        public ActionResult Index()
        {
            var eSTADOCUENTALABORATORIO = db.ESTADOCUENTALABORATORIO.Include(e => e.LABORATORIO);
            return View(eSTADOCUENTALABORATORIO.ToList());
        }

        // GET: ESTADOCUENTALABORATORIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCUENTALABORATORIO eSTADOCUENTALABORATORIO = db.ESTADOCUENTALABORATORIO.Find(id);
            if (eSTADOCUENTALABORATORIO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOCUENTALABORATORIO);
        }

        // GET: ESTADOCUENTALABORATORIOs/Create
        public ActionResult Create()
        {
            ViewBag.IdLaboratorio = new SelectList(db.LABORATORIO, "IdLaboratorio", "Nombre");
            return View();
        }

        // POST: ESTADOCUENTALABORATORIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstadoL,Monto,Abono,Faltante,IdLaboratorio")] ESTADOCUENTALABORATORIO eSTADOCUENTALABORATORIO)
        {
            if (ModelState.IsValid)
            {
                db.ESTADOCUENTALABORATORIO.Add(eSTADOCUENTALABORATORIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLaboratorio = new SelectList(db.LABORATORIO, "IdLaboratorio", "Nombre", eSTADOCUENTALABORATORIO.IdLaboratorio);
            return View(eSTADOCUENTALABORATORIO);
        }

        // GET: ESTADOCUENTALABORATORIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCUENTALABORATORIO eSTADOCUENTALABORATORIO = db.ESTADOCUENTALABORATORIO.Find(id);
            if (eSTADOCUENTALABORATORIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLaboratorio = new SelectList(db.LABORATORIO, "IdLaboratorio", "Nombre", eSTADOCUENTALABORATORIO.IdLaboratorio);
            return View(eSTADOCUENTALABORATORIO);
        }

        // POST: ESTADOCUENTALABORATORIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstadoL,Monto,Abono,Faltante,IdLaboratorio")] ESTADOCUENTALABORATORIO eSTADOCUENTALABORATORIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADOCUENTALABORATORIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLaboratorio = new SelectList(db.LABORATORIO, "IdLaboratorio", "Nombre", eSTADOCUENTALABORATORIO.IdLaboratorio);
            return View(eSTADOCUENTALABORATORIO);
        }

        // GET: ESTADOCUENTALABORATORIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCUENTALABORATORIO eSTADOCUENTALABORATORIO = db.ESTADOCUENTALABORATORIO.Find(id);
            if (eSTADOCUENTALABORATORIO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOCUENTALABORATORIO);
        }

        // POST: ESTADOCUENTALABORATORIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADOCUENTALABORATORIO eSTADOCUENTALABORATORIO = db.ESTADOCUENTALABORATORIO.Find(id);
            db.ESTADOCUENTALABORATORIO.Remove(eSTADOCUENTALABORATORIO);
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
