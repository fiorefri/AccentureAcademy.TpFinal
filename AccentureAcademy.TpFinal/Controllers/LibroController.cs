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

        // Json 
        public JsonResult JSONListaLibros()
        {
            return Json(db.Libros.Select(lib => new { Id = lib.Id, Titulo = lib.Titulo, ISBN = lib.ISBN }).ToList(), JsonRequestBehavior.AllowGet);
        }

        // Mostrar
        public ActionResult Mostrar()
        {
            List<Libros> libros = db.Libros.ToList();
            ViewBag.Titulo = "Ver Libros";

            return View(libros);
        }

        // Ver Mas
        public ActionResult VerMas(int id)
        {
            Libros libro = db.Libros.Find(id);

            return View(libro);
        } 

        // Agregar
        public ActionResult Agregar()
        {
            ViewBag.Titulo = "Agregar Libros";

            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Libros nuevoLibro, IEnumerable<int> autores)
        {
            if (nuevoLibro == null)
            {
                return Content("No se pudo ingresar el libro a la base de datos. Pruebe nuevamente");
            }

            foreach (int autor in autores)
            {
                Autores autorElegido = db.Autores.Find(autor);

                nuevoLibro.Autores.Add(autorElegido);
            }

            db.Libros.Add(nuevoLibro);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }

        // Editar
        public ActionResult Editar(int id)
        {
            Libros libro = db.Libros.Find(id);
            ViewBag.Titulo = "Editar Libro";

            return View(libro);
        }
        
        [HttpPost]
        public ActionResult Editar(Libros libro, IEnumerable<int> autores)
        {
            Libros libroNuevo = db.Libros.Find(libro.id);
            libroNuevo.Autores.Clear();

            foreach (int autorActual in autores)
            {
                Autores escritoPor = db.Autores.Find(autorActual);
                libroNuevo.Autores.Add(escritoPor);
            }

            db.SaveChanges();

            return View("Mostrar");
        }

        // Eliminar
        public ActionResult Eliminar(int id)
        {
            Libros libro = db.Libros.Find(id);
            db.Libros.Remove(libro);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }
    }
}
