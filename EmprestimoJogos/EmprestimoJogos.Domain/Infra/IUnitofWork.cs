using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.Infra
{
    public interface IUnitofWork : IDisposable
    {
        object Commit(object objeto);
        void Commit();
    }
}
