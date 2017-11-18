using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentalDB.Models;

namespace DentalDB.Controllers
{

    public class HistorialViewController : Controller
    {
        DentalDBEntities1 db = new DentalDBEntities1();
        // GET: HistorialView
        public ActionResult Index(string busqueda)
        {
            var query = from h in db.HistorialView
                        select h;

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(x => x.Nombre.StartsWith(busqueda));
            }
            
            return View(query.ToList());
        }

        // GET: HistorialView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistorialView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialView/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HistorialView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistorialView/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HistorialView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistorialView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
