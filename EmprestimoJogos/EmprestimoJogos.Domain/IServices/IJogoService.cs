using EmprestimoJogos.Domain.Models;
using System.Linq;

namespace EmprestimoJogos.Domain.IServices
{
    public interface IJogoService
    {
        IQueryable Get();
        Jogo Get(int id);
        Jogo Salva(Jogo Jogo);
        Jogo Atualiza(int id, Jogo Jogo);        
        Jogo Delete(int id);
        Emprestimo Emprestar(Emprestimo emprestimo);
        Emprestimo Devolver(Emprestimo emprestimo);
    }
}
