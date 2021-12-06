using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoDAM.Controllers
{
    /// <summary>
    /// Clase controlador de la página inicial.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Método que devuelve la vista que se va a mostrar de índice.
        /// </summary>
        /// <returns>La vista index</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "SEWESER";

            return View();
        }
    }
}
