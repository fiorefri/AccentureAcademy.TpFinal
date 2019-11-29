using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class NivelController : Controller
    {
        private AccentureAcademyDBEntities db;
        public NivelController()
        {
            db = new AccentureAcademyDBEntities();
        }

        // Mostrar
        public ActionResult Mostrar()
        {
            List<Niveles> niveles = db.Niveles.ToList();

            return View(niveles);
        }

        // Agregar
        public ActionResult Agregar()
        {
            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Niveles nuevoNivel)
        {
            if (nuevoNivel == null)
            {
                return Content("No se pudo ingresar el nivel a la base de datos. Pruebe nuevamente");
            }

            db.Niveles.Add(nuevoNivel);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }

        // Editar
        public ActionResult Editar(int id)
        {
            Niveles nivel = db.Niveles.Find(id);

            return View(nivel);
        }

        [HttpPost]
        public ActionResult Editar(Niveles nivel)
        {
            if (ModelState.IsValid)
            {
                db.Niveles.Attach(nivel);
                db.Entry(nivel).State = EntityState.Modified;
                db.SaveChanges();

                return Content("El nivel se ha actualizado satisfactoriamente");
            }

            return new HttpStatusCodeResult(505, "Internal server Error. Hacker Detected");
        }

        // Eliminar
        public ActionResult Eliminar(int id)
        {
            Niveles nivel = db.Niveles.Find(id);
            db.Niveles.Remove(nivel);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }
    }
}