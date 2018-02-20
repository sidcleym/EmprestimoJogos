using EmprestimoJogos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmprestimoJogos.Models
{
    public class ModelEmprestimo
    {
        public Emprestimo Emprestimo { get; set; }
        public IList<Amigo> Amigos { get; set; }
    }
}