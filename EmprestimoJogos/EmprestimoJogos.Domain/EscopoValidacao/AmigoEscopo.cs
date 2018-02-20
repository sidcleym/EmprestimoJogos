using EmprestimoJogos.Domain.Infra.Notificacoes;
using EmprestimoJogos.Domain.Models;
using System.Linq;

namespace EmprestimoJogos.Domain.EscopoValidacao
{
    public class AmigoEscopo: EscopoBase
    {
        public static bool SalvarIsValid(Amigo Amigo)
        {
           
            if (Amigo == null)
            {
                DominioNotificacoes validation = new DominioNotificacoes(new Erros(0, "", "Nenhuma informação informada", "", "Informe as informações"));
                _notificacoes = "Nenhuma informação informada";
                return AssertionConcern.IsSatisfiedBy(validation);
            }

           

            var retorno = AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(Amigo, "Nenhuma informação informada"),					
                AssertionConcern.AssertLength(Amigo.Email,6,100,"O Email deve conter até 100 caracteres"),
                AssertionConcern.AssertLength(Amigo.Telefone,11,11, "O telefone deverá conter 11 crácteres")
                
                  //AssertionConcern.AssertContains(Amigo.desativado,"O campo desativado está incorreto","S","N"),
                //AssertionConcern.AssertContains(Amigo.acessoPorHora, "O campo acesso hora está incorreto", "S", "N")
            );

          

            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;

        }

        public static bool AtualizarIsValid(Amigo Amigo)
        {
           
            if (Amigo == null)
            {
                DominioNotificacoes validation = new DominioNotificacoes(new Erros(0, "", "Nenhuma informação informada", "", "Informe as informações"));
                _notificacoes = "Nenhuma informação informada";
                return AssertionConcern.IsSatisfiedBy(validation);
            }

            var retorno = AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(Amigo, "Nenhuma informação informada"),
                AssertionConcern.AssertLength(Amigo.Email, 6, 100, "O Email deve conter até 100 caracteres"),
                AssertionConcern.AssertLength(Amigo.Telefone, 11, 11, "O telefone deverá conter 11 crácteres")

            //AssertionConcern.AssertContains(Amigo.desativado,"O campo desativado está incorreto","S","N"),
            //AssertionConcern.AssertContains(Amigo.acessoPorHora, "O campo acesso hora está incorreto", "S", "N")
            );


            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;
        }


        public static bool ExcluirIsValid(Amigo Amigo)
        {
           // TUser.User.Identity.Name
            var retorno = AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(Amigo, "Amigo inexistente")
                //AssertionConcern.AssertTrue(TUser.isAdmin,"É necessário ser um administrador para excluir usuários! ")
            );
            

            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;
        }
    }
}
