using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class LibroController : Controller
    {
        private AccentureAcademyDBEntities db;
        public LibroController()
        {
            db = new AccentureAcademyDBEntities();
        }

        // Mostrar
        public ActionResult Mostrar()
        {
            List<Libros> libros = db.Libros.ToList();

            return View(libros);
        }

        // Agregar
        public ActionResult Agregar()
        {
            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Libros nuevoLibro)
        {
            if (nuevoLibro == null)
            {
                return Content("No se pudo ingresar el libro a la base de datos. Pruebe nuevamente");
            }

            db.Libros.Add(nuevoLibro);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }

        // Editar
    }
}