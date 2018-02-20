

namespace EmprestimoJogos.Domain.Infra.Notificacoes
{
    public static class DominioEvento 
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IDominioEvento
        {
            try
            {
                if (Container != null)
                {
                    var obj = Container.GetService(typeof(IManipulador<T>));
                    ((IManipulador<T>)obj).Manipula(args);
                }
            }
            catch
            {
                //throw;
            }
        }

    }
}
