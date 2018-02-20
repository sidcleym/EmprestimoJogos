using EmprestimoJogos.Domain.Infra;
using EmprestimoJogos.Domain.Infra.Notificacoes;
using EmprestimoJogos.Domain.IServices;
using EmprestimoJogos.Domain.Service;
using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace EmprestimoJogos.App_Start
{
    public class IocConfig
    {
        public static void ConfigurarDependencias()
        {
            //Cria o Container 
            IKernel kernel = new StandardKernel();
            
            
            kernel.Bind<DataContext>().To<DataContext>();
            kernel.Bind<IManipulador<DominioNotificacoes>>().To<DominioNotificacoesManipulador> ();
            kernel.Bind<IUnitofWork>().To<UnitofWork>();
            kernel.Bind<IUsuarioService>().To<UsuarioService>();
            kernel.Bind<IAmigoService>().To<AmigoService>();
            kernel.Bind<IJogoService>().To<JogoService>();
            //Registra o container no ASP.NET
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            DominioEvento.Container = new DominioEventosContainer(DependencyResolver.Current);

            //DataContext.connectionString = HttpContext.Current.Request.Url.Host;
           

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