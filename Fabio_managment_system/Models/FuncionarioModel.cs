using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fabio_managment_system.Models
{
    public class FuncionarioModel
    {
        public int Id_funcionario { get; set; }
        public String Nome { get; set; }
        public String Morada { get; set; }
        public String Idade { get; set; }
        public String Cargo { get; set; }
    }
}