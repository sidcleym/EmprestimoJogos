using EmprestimoJogos.Domain.Infra.Notificacoes;
using EmprestimoJogos.Domain.Models;
using System.Linq;

namespace EmprestimoJogos.Domain.EscopoValidacao
{
    public class JogoEscopo: EscopoBase
    {
        public static bool SalvarIsValid(Jogo Jogo)
        {
           
            if (Jogo == null)
            {
                DominioNotificacoes validation = new DominioNotificacoes(new Erros(0, "", "Nenhum dado informado", "", "Informe os dados"));
                _notificacoes = "Nenhum dado informado";
                return AssertionConcern.IsSatisfiedBy(validation);
            }

           

            var retorno = AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(Jogo, "Nenhum dado informado"),					
                AssertionConcern.AssertLength(Jogo.Descricao,6,100,"A descrição do jogo deve conter até 100 caracteres"),
                AssertionConcern.AssertIsGreaterThan(Jogo.Ano,1900,"O Ano deverá ser maior que 1900")
                
                  //AssertionConcern.AssertContains(Jogo.desativado,"O campo desativado está incorreto","S","N"),
                //AssertionConcern.AssertContains(Jogo.acessoPorHora, "O campo acesso hora está incorreto", "S", "N")
            );

          

            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;

        }

        public static bool AtualizarIsValid(Jogo Jogo)
        {

            if (Jogo == null)
            {
                DominioNotificacoes validation = new DominioNotificacoes(new Erros(0, "", "Nenhum dado informado", "", "Informe os dados"));
                _notificacoes = "Nenhum dado informado";
                return AssertionConcern.IsSatisfiedBy(validation);
            }


            var retorno = AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(Jogo, "Nenhuma informação informada"),
                AssertionConcern.AssertLength(Jogo.Descricao, 6, 100, "A descrição do jogo deve conter até 100 caracteres"),
                AssertionConcern.AssertIsGreaterThan(Jogo.Ano, 1900, "O Ano deverá ser maior que 1900")

            //AssertionConcern.AssertContains(Jogo.desativado,"O campo desativado está incorreto","S","N"),
            //AssertionConcern.AssertContains(Jogo.acessoPorHora, "O campo acesso hora está incorreto", "S", "N")
            );


            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;
        }


        public static bool ExcluirIsValid(Jogo Jogo)
        {
           // TUser.User.Identity.Name
            var retorno = AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(Jogo, "Jogo inexistente"),
                AssertionConcern.AssertTrue(Jogo.Emprestado==false, "Este jogo não pode ser excluído, pois ainda não foi devolvido!")
            );
            

            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;
        }
    }
}
