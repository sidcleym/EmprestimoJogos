using EmprestimoJogos.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.Models
{
    public class Amigo:ModelBase
    {

        [Required(ErrorMessage ="O nome é obrigatório")]
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        [ForeignKey("AmigoId")]
        public IList<Emprestimo> Emprestimo { get; set; }

    }
}
