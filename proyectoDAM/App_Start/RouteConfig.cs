using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace proyectoDAM
{
    /// <summary>
    /// Clase que gestiona las rutas 
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Clase que gestiona las rutas
        /// </summary>
        /// <param name="routes">Se mapea la ruta</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
