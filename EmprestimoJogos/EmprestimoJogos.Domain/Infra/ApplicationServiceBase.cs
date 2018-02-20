using EmprestimoJogos.Domain.Infra.Notificacoes;

namespace EmprestimoJogos.Domain.Infra
{
    public class ApplicationServiceBase
    {
        private IUnitofWork _unitOfWork;
        private IManipulador<DominioNotificacoes> _notifications;

        public ApplicationServiceBase()
        {

        }
        public ApplicationServiceBase(IUnitofWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._notifications = DominioEvento.Container.GetService<IManipulador<DominioNotificacoes>>();
        }

        public object Commit(object objeto = null)
        {
            if (_notifications.temNotificacoes())
                return null;
            
            return _unitOfWork.Commit(objeto);
           // return true;
        }



        public bool Commit()
        {
            if (_notifications.temNotificacoes())
                return false;
            
            _unitOfWork.Commit();
            return true;
        }
    }
}
