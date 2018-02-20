using EmprestimoJogos.Domain.Infra.Notificacoes;
using EmprestimoJogos.Domain.IServices;
using EmprestimoJogos.Domain.Service;
using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace EmprestimoJogos.Domain.Infra
{
    public static class TConexao
    {
        public static  DataContext context;        
        public static UnitofWork  unitofWork;
        public static IManipulador<DominioNotificacoes> notifications;
        
        public static void ResolveDependencias()
        {
            //IKernel kernel = new StandardKernel();
            //
            //kernel.Bind<DataContext>().To<DataContext>();
            //kernel.Bind<IManipulador<DominioNotificacoes>>().To<DominioNotificacoesManipulador>();
            //kernel.Bind<IUnitofWork>().To<UnitofWork>();
            //
            ////Registra o container no ASP.NET
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            //DominioEvento.Container = new DominioEventosContainer(DependencyResolver.Current);
            //Cria o Container
            IKernel kernel = new StandardKernel();


            kernel.Bind<DataContext>().To<DataContext>();
            kernel.Bind<IManipulador<DominioNotificacoes>>().To<DominioNotificacoesManipulador>();
            kernel.Bind<IUnitofWork>().To<UnitofWork>();
            kernel.Bind<IUsuarioService>().To<UsuarioService>();
            kernel.Bind<IAmigoService>().To<AmigoService>();
            kernel.Bind<IJogoService>().To<JogoService>();
            //Registra o container no ASP.NET
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            DominioEvento.Container = new DominioEventosContainer(DependencyResolver.Current);
        }

        public static void Open()
        {
           ResolveDependencias();          
           context    = new DataContext();           
           unitofWork = new UnitofWork(context);
        }

        public static IList<DominioNotificacoes> Notificacoes()
        {
            notifications = DominioEvento.Container.GetService<IManipulador<DominioNotificacoes>>();

            return notifications.Notifica().ToList();
        }

        public static void Dispose(){
            context.Dispose();
        }
    }



    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectDependencyResolver(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
    }
}
