using System.Collections.Generic;

namespace EmprestimoJogos.Domain.Infra.Notificacoes
{
    public class DominioNotificacoesManipulador : IManipulador<DominioNotificacoes>
    {
        private List<DominioNotificacoes> _notifications;

        public DominioNotificacoesManipulador()
        {
            _notifications = new List<DominioNotificacoes>();
        }

        public void Manipula(DominioNotificacoes args)
        {
            _notifications.Add(args);
        }

        public IEnumerable<DominioNotificacoes> Notifica()
        {
            
            return GetValue();
        }

        private List<DominioNotificacoes> GetValue()
        {
            return _notifications;
        }

        public bool temNotificacoes()
        {
            return GetValue().Count > 0;
        }

        public void Dispose()
        {
            this._notifications = new List<DominioNotificacoes>();
        }
    }
}
