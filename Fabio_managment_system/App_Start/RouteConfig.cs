using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fabio_managment_system
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Dashboard",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Dashboard", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AddFuncionario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Funcionario", action = "AddFuncionario", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Adicionar_funcionario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Funcionario", action = "Adicionar_funcionario", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Todos_funcionario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Funcionario", action = "Todos_funcionarios", id = UrlParameter.Optional }
            );
        }
    }
}
