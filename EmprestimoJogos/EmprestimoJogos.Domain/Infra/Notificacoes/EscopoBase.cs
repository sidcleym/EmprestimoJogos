namespace EmprestimoJogos.Domain.Infra.Notificacoes
{
    public class EscopoBase
    {
        public static string _notificacoes="";

        public static void CriaNotificacao(string pTitulo, string mensagem)
        {
            _notificacoes = mensagem;
            var erro = new Erros(0, "", pTitulo, "", mensagem);
            DominioNotificacoes validation = new DominioNotificacoes(erro);                
            AssertionConcern.IsSatisfiedBy(validation);            
        }
    }
}
