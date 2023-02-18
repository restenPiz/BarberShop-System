using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Fabio_managment_system.Models;

namespace Fabio_managment_system.Controllers
{
    public class FuncionarioController : Controller
    {
        BarberEntities Contextobj = new BarberEntities();
        // GET: Funcionario
        public ActionResult AddFuncionario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar_funcionario(FuncionarioModel obj)
        {
            Contextobj.Funcionario.Add(new Funcionario() { Nome = obj.Nome, Morada = obj.Morada, Idade=obj.Idade, Cargo=obj.Cargo });
            Contextobj.SaveChanges();

            var ComplaintRecord = Contextobj.Funcionario.ToList();

            return View("Todos_funcionarios", ComplaintRecord);
        }
        [HttpGet]
        public ActionResult Todos_funcionarios()
        {
            var ComplaintRecord = Contextobj.Funcionario.ToList();

            return View("Todos_funcionarios", ComplaintRecord);
        }


        [HttpGet]
        public ActionResult Editar_funcionario(int Id_funcionario)
        {
            //Select my data where my id was found
            var DepartResp = (from item in Contextobj.Funcionario
                              where item.Id_funcionario == Id_funcionario
                              select item).First();

            return View("Editar_funcionario", DepartResp);
        }

        [HttpPost]
        public ActionResult Actualizar_funcionario(Funcionario obj)
        {
            var DepartResp = (from item in Contextobj.Funcionario
                              where item.Id_funcionario == obj.Id_funcionario
                              select item).First();

            DepartResp.Nome = obj.Nome;
            DepartResp.Morada = obj.Morada;
            DepartResp.Cargo = obj.Cargo;
            DepartResp.Idade = obj.Idade;

            Contextobj.SaveChanges();

            var DepartRecord = Contextobj.Funcionario.ToList();

            return View("Todos_funcionarios", DepartRecord);
        }

        public ActionResult Eliminar_funcionario(int Id_funcionario)
        {
            var DepartResp = (from item in Contextobj.Funcionario
                              where item.Id_funcionario == Id_funcionario
                              select item).First();

            Contextobj.Funcionario.Remove(DepartResp);
            Contextobj.SaveChanges();

            var DepartRecord = Contextobj.Funcionario.ToList();

            return View("Todos_funcionarios", DepartRecord);
        }

    }
}