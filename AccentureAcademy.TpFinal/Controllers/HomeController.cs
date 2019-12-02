using AccentureAcademy.TpFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademy.TpFinal.Controllers
{
    public class HomeController : Controller
    {
        private AccentureAcademyDBEntities db;
        public HomeController()
        {
            var db = new AccentureAcademyDBEntities();
        } 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public JsonResult ListaLibrosJSON()
        {
            return Json(db.Libros.Select(libro => new {
                Id = libro.Id,
                Titulo = libro.Titulo,
                ISBN = libro.ISBN
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}