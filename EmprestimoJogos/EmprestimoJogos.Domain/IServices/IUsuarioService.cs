using EmprestimoJogos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.IServices
{
    public interface IUsuarioService
    {
        IQueryable Get();
        Usuario Get(int id);
        Usuario Get(string login);
        Usuario Salva(Usuario usuario);
        Usuario Atualiza(int id, Usuario usuario);
        
        Usuario Delete(int id);
        bool isLoginValid(string login, string senha);
    }
}
