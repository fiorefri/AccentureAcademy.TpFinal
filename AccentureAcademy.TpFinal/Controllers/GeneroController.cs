using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class GeneroController : Controller
    {
        private AccentureAcademyDBEntities db;
        public GeneroController()
        {
            db = new AccentureAcademyDBEntities();
        }

        // Json
        public JsonResult JSONListaGeneros()
        {
            return Json(db.Generos.Select(gen => new { Id = gen.Id, Genero = gen.Genero }).ToList(), JsonRequestBehavior.AllowGet);
        }

        // Mostrar
        public ActionResult Mostrar()
        {
            List<Generos> generos = db.Generos.ToList();
            ViewBag.Titulo = "Ver Géneros";

            return View(generos);
        }

        // Agregar
        public ActionResult Agregar()
        {
            ViewBag.Titulo = "Agregar Género";

            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Generos nuevoGenero)
        {
            if (nuevoGenero == null)
            {
                return Content("No se pudo ingresar el genero a la base de datos. Pruebe nuevamente");
            }

            var db = new AccentureAcademyDBEntities();
            db.Generos.Add(nuevoGenero);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }

        // Editar
        public ActionResult Editar(int id)
        {
            Generos genero = db.Generos.Find(id);
            ViewBag.Titulo = "Editar Género";

            return View(genero);
        }

        [HttpPost]
        public ActionResult Editar(Generos genero)
        {
            if (ModelState.IsValid)
            {
                db.Generos.Attach(genero);
                db.Entry(genero).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Mostrar");
            }

            return new HttpStatusCodeResult(505, "Internal server Error. Hacker Detected");
        }

        // Eliminar
        public ActionResult Eliminar(int id)
        {
            Generos genero = db.Generos.Find(id);
            db.Generos.Remove(genero);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }
    }
}