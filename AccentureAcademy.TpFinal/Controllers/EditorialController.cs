using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class EditorialController : Controller
    {
        private AccentureAcademyDBEntities db;
        public EditorialController()
        {
            db = new AccentureAcademyDBEntities();
        }

        // Mostrar
        public ActionResult Mostrar()
        {
            List<Editoriales> editoriales = db.Editoriales.ToList();
            ViewBag.Titulo = "Editoriales";

            return View(editoriales);
        }

        // Agregar
        public ActionResult Agregar()
        {
            ViewBag.Titulo = "Agregar Editorial";

            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Editoriales nuevaEditorial)
        {
            if (nuevaEditorial == null)
            {
                return Content("No se pudo ingresar la editorial a la base de datos. Pruebe nuevamente");
            }

            var db = new AccentureAcademyDBEntities();
            db.Editoriales.Add(nuevaEditorial);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }

        // Editar
        public ActionResult Editar(int id)
        {
            Editoriales editorial = db.Editoriales.Find(id);
            ViewBag.Titulo = "Editar Editorial";

            return View(editorial);
        }

        [HttpPost]
        public ActionResult Editar(Editoriales editorial)
        {
            if (ModelState.IsValid)
            {
                db.Editoriales.Attach(editorial);
                db.Entry(editorial).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Mostrar");
            }
            
            return new HttpStatusCodeResult(505, "Internal server Error. Hacker Detected");
        }

        // Eliminar 
        public ActionResult Eliminar(int id)
        {
            Editoriales editorial = db.Editoriales.Find(id);
            db.Editoriales.Remove(editorial);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }
    }
}