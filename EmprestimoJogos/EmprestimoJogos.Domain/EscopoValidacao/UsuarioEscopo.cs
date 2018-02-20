using EmprestimoJogos.Domain.Infra.Notificacoes;
using EmprestimoJogos.Domain.Models;
using System.Linq;

namespace EmprestimoJogos.Domain.EscopoValidacao
{
    public class UsuarioEscopo: EscopoBase
    {
        public static bool SalvarIsValid(Usuario usuario)
        {
           
            if (usuario == null)
            {
                DominioNotificacoes validation = new DominioNotificacoes(new Erros(0, "", "Nenhuma informação informada", "", "Informe as informações"));
                _notificacoes = "Nenhuma informação informada";
                return AssertionConcern.IsSatisfiedBy(validation);
            }

           

            var retorno = AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(usuario, "Nenhuma informação informada"),					
                AssertionConcern.AssertLength(usuario.Email,6,100,"O Email deve conter até 100 caracteres"),
                AssertionConcern.AssertLength(usuario.Senha,1,8, "A senha deve conter de 1 a 8"),
                AssertionConcern.AssertIsNullorWhiteSpace(usuario.Email, "O login deve ser informado"),
                AssertionConcern.AssertMatches(usuario.Senha, usuario.SenhaConfirmacao,"As senhas não coincidem"),              
                AssertionConcern.AssertIsTrue(usuario.SenhaCriptografada!=null,"A senha criptografada deve ser informada","Preenchimento Incorreto")
                //AssertionConcern.AssertContains(usuario.desativado,"O campo desativado está incorreto","S","N"),
                //AssertionConcern.AssertContains(usuario.acessoPorHora, "O campo acesso hora está incorreto", "S", "N")
            );

          

            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;

        }

        public static bool AtualizarIsValid(Usuario usuario)
        {
           
            if (usuario == null)
            {
                DominioNotificacoes validation = new DominioNotificacoes(new Erros(0, "", "Nenhuma informação informada", "", "Informe as informações"));
                _notificacoes = "Nenhuma informação informada";
                return AssertionConcern.IsSatisfiedBy(validation);
            }

            var retorno = AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(usuario, "Nenhuma informação informada"),
                AssertionConcern.AssertLength(usuario.Email, 6, 100, "O Email deve conter até 100 caracteres"),
                AssertionConcern.AssertLength(usuario.Senha, 1, 8, "A senha deve conter de 1 a 8"),
                AssertionConcern.AssertIsNullorWhiteSpace(usuario.Email, "O login deve ser informado"),
                AssertionConcern.AssertMatches(usuario.Senha, usuario.SenhaConfirmacao, "As senhas não coincidem"),
                AssertionConcern.AssertIsTrue(usuario.SenhaCriptografada != null, "A senha criptografada deve ser informada", "Preenchimento Incorreto")
                //AssertionConcern.AssertContains(usuario.desativado,"O campo desativado está incorreto","S","N"),
                //AssertionConcern.AssertContains(usuario.acessoPorHora, "O campo acesso hora está incorreto", "S", "N")
            );


            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;
        }


        public static bool ExcluirIsValid(Usuario usuario)
        {
           // TUser.User.Identity.Name
            var retorno = AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(usuario, "Usuario inexistente")
                //AssertionConcern.AssertTrue(TUser.isAdmin,"É necessário ser um administrador para excluir usuários! ")
            );
            

            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;
        }
    }
}
