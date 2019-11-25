using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Mostrar()
        {
            var db = new AccentureAcademyDBEntities();
            List<Libros> libros = db.Libros.ToList();

            return View(libros);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Libros nuevoLibro)
        {
            if (nuevoLibro == null)
            {
                return Content("No se pudo ingresar el libro a la base de datos. Pruebe nuevamente");
            }

            var db = new AccentureAcademyDBEntities();
            db.Libros.Add(nuevoLibro);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }
    }
}