using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Fabio_managment_system.Models;

namespace Fabio_managment_system.Controllers
{
    public class CorteController : Controller
    {

        BarberEntities Contextobj = new BarberEntities();
        // GET: Corte
        public ActionResult AddCorte()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar_corte(CorteModel obj)
        {
            Contextobj.Corte.Add(new Corte() { Nome = obj.Nome, Preco = obj.Preco });
            Contextobj.SaveChanges();

            var ComplaintRecord = Contextobj.Corte.ToList();

            return View("Todos_cortes", ComplaintRecord);
        }
        [HttpGet]
        public ActionResult Todos_cortes()
        {
            var ComplaintRecord = Contextobj.Corte.ToList();

            return View("Todos_cortes", ComplaintRecord);
        }


        [HttpGet]
        public ActionResult Editar_corte(int Id_corte)
        {
            //Select my data where my id was found
            var DepartResp = (from item in Contextobj.Corte
                              where item.Id_corte == Id_corte
                              select item).First();

            return View("Editar_corte", DepartResp);
        }

        [HttpPost]
        public ActionResult Actualizar_corte(Corte obj)
        {
            var DepartResp = (from item in Contextobj.Corte
                              where item.Id_corte == obj.Id_corte
                              select item).First();

            DepartResp.Nome = obj.Nome;
            DepartResp.Preco = obj.Preco;

            Contextobj.SaveChanges();

            var DepartRecord = Contextobj.Corte.ToList();

            return View("Todos_cortes", DepartRecord);
        }

        public ActionResult Eliminar_corte(int Id_corte)
        {
            var DepartResp = (from item in Contextobj.Corte
                              where item.Id_corte == Id_corte
                              select item).First();

            Contextobj.Corte.Remove(DepartResp);
            Contextobj.SaveChanges();

            var DepartRecord = Contextobj.Corte.ToList();

            return View("Todos_cortes", DepartRecord);
        }
    }
}