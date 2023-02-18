using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Fabio_managment_system.Models;
using System.Web.Security;

namespace Fabio_managment_system.Controllers
{
    public class HomeController : Controller
    {
        BarberEntities Contextobj = new BarberEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult Login(UsuarioModel model, string returnUrl)
        {
            var dataItem = Contextobj.User_person.Where(
                x => x.Nome == model.Nome &&
                x.Senha == model.Senha
                ).First();

            //Start the validation condition
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.Nome, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Dashboard");
                }
            }
            else
            {
                ModelState.AddModelError("", "Usuario ou password invalido.");
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}