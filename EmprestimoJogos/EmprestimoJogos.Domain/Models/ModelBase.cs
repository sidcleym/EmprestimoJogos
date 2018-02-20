using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.Models
{
    public abstract class ModelBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Data de inclusão", Description = "Data de inclusão")]
        public DateTime DtInclusao { get; set; }
        [Display(Name = "Data de atualização", Description = "Data de atualização")]
        public DateTime? DtAtualizacao { get; set; }
        public string Observacao { get; set; }

    }
}
