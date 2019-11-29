using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class AutorController : Controller
    {
        private AccentureAcademyDBEntities db;
        public AutorController()
        {
            db = new AccentureAcademyDBEntities();
        }

        // Mostrar
        public ActionResult Mostrar()
        {
            List<Autores> autores = db.Autores.ToList();

            return View(autores);
        }

        // Agregar
        public ActionResult Agregar()
        {
            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Autores nuevoAutor)
        {
            if (nuevoAutor == null)
            {
                return Content("No se pudo ingresar el autor a la base de datos. Pruebe nuevamente");
            }

            var db = new AccentureAcademyDBEntities();
            db.Autores.Add(nuevoAutor);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }

        // Editar 
        public ActionResult Editar(int id)
        {
            Autores autor = db.Autores.Find(id);

            return View(autor);
        }

        [HttpPost]
        public ActionResult Editar(Autores autor)
        {
            if (ModelState.IsValid)
            {
                db.Autores.Attach(autor);
                db.Entry(autor).State = EntityState.Modified;
                db.SaveChanges();

                return Content("Se actualizo correctamente el autor");
            }

            return new HttpStatusCodeResult(505, "Internal server Error. Hacker Detected");
        }

        // Eliminar 
        public ActionResult Eliminar(int id)
        {
            Autores autor = db.Autores.Find(id);
            db.Autores.Remove(autor);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }
    }
}