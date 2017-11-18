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
    public class ESTADOTRABAJOesController : Controller
    {
        private DentalDBEntities1 db = new DentalDBEntities1();

        // GET: ESTADOTRABAJOes
        public ActionResult Index()
        {
            return View(db.ESTADOTRABAJO.ToList());
        }

        // GET: ESTADOTRABAJOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOTRABAJO eSTADOTRABAJO = db.ESTADOTRABAJO.Find(id);
            if (eSTADOTRABAJO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOTRABAJO);
        }

        // GET: ESTADOTRABAJOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESTADOTRABAJOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstadoT,Estado")] ESTADOTRABAJO eSTADOTRABAJO)
        {
            if (ModelState.IsValid)
            {
                db.ESTADOTRABAJO.Add(eSTADOTRABAJO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSTADOTRABAJO);
        }

        // GET: ESTADOTRABAJOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOTRABAJO eSTADOTRABAJO = db.ESTADOTRABAJO.Find(id);
            if (eSTADOTRABAJO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOTRABAJO);
        }

        // POST: ESTADOTRABAJOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstadoT,Estado")] ESTADOTRABAJO eSTADOTRABAJO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADOTRABAJO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSTADOTRABAJO);
        }

        // GET: ESTADOTRABAJOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOTRABAJO eSTADOTRABAJO = db.ESTADOTRABAJO.Find(id);
            if (eSTADOTRABAJO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOTRABAJO);
        }

        // POST: ESTADOTRABAJOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADOTRABAJO eSTADOTRABAJO = db.ESTADOTRABAJO.Find(id);
            db.ESTADOTRABAJO.Remove(eSTADOTRABAJO);
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
