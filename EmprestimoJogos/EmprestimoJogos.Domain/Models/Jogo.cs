using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoJogos.Domain.Models
{
    public class Jogo:ModelBase
    {
        public string Descricao { get; set; }
        public int Ano { get; set; }

       
        public bool Emprestado { get; set; }

        [ForeignKey("JogoId")]
        public IList<Emprestimo> Historico { get; set; }
    }
}
