using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class GeneroController : Controller
    {
        // GET: Genero
        public ActionResult Mostrar()
        {
            var db = new AccentureAcademyDBEntities();
            List<Generos> generos = db.Generos.ToList();

            return View(generos);
        }

        public ActionResult Agregar()
        {
            return View();
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
    }
}