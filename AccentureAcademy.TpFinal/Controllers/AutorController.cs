using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Mostrar()
        {
            var db = new AccentureAcademyDBEntities();
            List<Autores> autores = db.Autores.ToList();

            return View(autores);
        }

        public ActionResult Agregar()
        {
            return View();
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
    }
}