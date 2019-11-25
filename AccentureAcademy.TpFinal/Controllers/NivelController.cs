using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class NivelController : Controller
    {
        // GET: Nivel
        public ActionResult Mostrar()
        {
            var db = new AccentureAcademyDBEntities();
            List<Niveles> niveles = db.Niveles.ToList();

            return View(niveles);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Niveles nuevoNivel)
        {
            if (nuevoNivel == null)
            {
                return Content("No se pudo ingresar el nivel a la base de datos. Pruebe nuevamente");
            }

            var db = new AccentureAcademyDBEntities();
            db.Niveles.Add(nuevoNivel);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }
    }
}