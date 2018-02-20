using EmprestimoJogos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.IServices
{
    public interface IAmigoService
    {
        IQueryable Get();
        Amigo Get(int id);
        Amigo Salva(Amigo Amigo);
        Amigo Atualiza(int id, Amigo Amigo);        
        Amigo Delete(int id);
    }
}
