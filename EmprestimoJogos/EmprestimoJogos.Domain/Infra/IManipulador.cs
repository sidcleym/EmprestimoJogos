
using EmprestimoJogos.Domain.Infra.Notificacoes;
using System;
using System.Collections.Generic;

namespace EmprestimoJogos.Domain.Infra
{
    public interface IManipulador<T> : IDisposable where T : IDominioEvento
    {
        void Manipula(T args);
        IEnumerable<T> Notifica();
        bool temNotificacoes();
    }
}
