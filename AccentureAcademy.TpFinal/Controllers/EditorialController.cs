using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class EditorialController : Controller
    {
        // GET: Editorial
        public ActionResult Mostrar()
        {
            var db = new AccentureAcademyDBEntities();
            List<Libros> editoriales = db.Libros.ToList();

            return View(editoriales);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Libros nuevaEditorial)
        {
            if (nuevaEditorial == null)
            {
                return Content("No se pudo ingresar la editorial a la base de datos. Pruebe nuevamente");
            }

            var db = new AccentureAcademyDBEntities();
            db.Libros.Add(nuevaEditorial);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }
    }
}