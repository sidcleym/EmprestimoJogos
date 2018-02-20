using EmprestimoJogos.App_Start;
using EmprestimoJogos.Domain.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EmprestimoJogos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IocConfig.ConfigurarDependencias();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            TConexao.Open();
        }


        protected void Application_EndRequest(object sender, EventArgs e)
        {           
            if (TConexao.context!=null)
                TConexao.Dispose();            
        }


    }
}
