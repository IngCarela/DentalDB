using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentalDB.Models;

namespace DentalDB.Controllers
{
    public class USUARIOController : Controller
    {
        DentalDBEntities1 db = new DentalDBEntities1();

        // GET: USUARIO
        public ActionResult Index(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                var query = db.USUARIO.Where(x => x.Nombre.Equals(usuario.Nombre) && x.Contrasena.Equals(usuario.Contrasena)).FirstOrDefault();
                if (query != null)
                {
                    Session["Id"] = usuario.IdUsuario.ToString();
                    Session["Nombre"] = usuario.Nombre.ToString();

                    return RedirectToAction("Index", "CITA");
                }
                else
                {
                    ViewBag.Message = "Error";
                }
                
            }
            return View(usuario);
        }

        // GET: USUARIO/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: USUARIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: USUARIO/Create
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

        // GET: USUARIO/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: USUARIO/Edit/5
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

        // GET: USUARIO/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: USUARIO/Delete/5
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

        [HttpGet]

        public ActionResult listado()
        {
            var query = from p in db.PACIENTE
                        join t in db.TRABAJO on p.IdPaciente equals t.IdTrabajo
                        //join l in db.LABORATORIO on p.IdPaciente equals l.IdLaboratorio
                        select new { p.Nombre, t.Tratamiento };
            return View();
        }
    }
}
