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
            ViewBag.Titulo = "Autores";

            return View(autores);
        }

        // Agregar
        public ActionResult Agregar()
        {
            ViewBag.Titulo = "Agregar Autor";

            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Autores nuevoAutor)
        {
            if (nuevoAutor == null)
            {
                return Content("No se pudo ingresar el autor a la base de datos. Pruebe nuevamente");
            }

            db.Autores.Add(nuevoAutor);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }

        // Editar 
        public ActionResult Editar(int id)
        {
            Autores autor = db.Autores.Find(id);
            ViewBag.Titulo = "Editar Autor";

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

                return RedirectToAction("Mostrar");
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