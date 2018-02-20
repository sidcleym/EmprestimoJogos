
using EmprestimoJogos.Domain.Models;
using System.Linq;

namespace EmprestimoJogos.Domain.IServices
{
    public interface IEmprestimoService
    {
        IQueryable Get();
        Emprestimo Get(int id);        
    }
}
