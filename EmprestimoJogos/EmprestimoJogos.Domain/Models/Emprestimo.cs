using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.Models
{
    public class Emprestimo: ModelBase
    {
        [ForeignKey("Amigo")]
        public int AmigoId { get; set; }
        public virtual Amigo Amigo { get; set; }

        [ForeignKey("Jogo")]
        public int JogoId { get; set; }
        public virtual Jogo Jogo { get; set; }

        public bool Ativo { get; set; }
        public DateTime? DtDevolucao { get; set; }
    }
}
