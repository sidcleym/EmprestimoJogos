using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;
using EmprestimoJogos.Domain.Service;
using EmprestimoJogos.Domain.Infra;
using EmprestimoJogos.Domain.Models;
using EmprestimoJogos.Domain.EscopoValidacao;
using EmprestimoJogos.Domain.Helpers;

namespace EmprestimoJogos.Tests
{
    [TestClass]
    public class JogoTeste
    {
        private JogoService  _service;                
              
        private void InicializaConexao()
        {
            TConexao.Open();
            _service          = new JogoService(TConexao.unitofWork, TConexao.context);
        }       
        private Jogo MontaEntidade()
        {
            Jogo entidade        = new Jogo();
            entidade.Descricao   = JogoHelper.GeraDescricao() +DateTime.Now;
            entidade.Ano         = 2018;
            return entidade;
        }

        private Jogo SalvaEntidade(bool dispose)
        {
            InicializaConexao();

            var entidade = MontaEntidade();
            var JogoSalvo = _service.Salva(entidade);

            if (dispose) TConexao.Dispose();

            return JogoSalvo;
        }

        [TestMethod]
        [TestCategory("Jogo")]
        public void Deve_Salvar_Jogo()
        {
            InicializaConexao();

            var entidade    = MontaEntidade();            
            var tituloSalvo = _service.Salva(entidade);

            TConexao.Dispose();
            Assert.AreNotEqual(null, tituloSalvo, JogoEscopo._notificacoes);
        }

        [TestMethod]
        [TestCategory("Jogo")]
        public void Deve_Emprestar()
        {
            InicializaConexao();

            var jogo = (_service.Get() as IQueryable<Jogo>).FirstOrDefault();
            var entidade = new Emprestimo();
            entidade.JogoId = jogo.Id;
            entidade.AmigoId = 1;

            var tituloSalvo = _service.Emprestar(entidade);

            TConexao.Dispose();
            Assert.AreNotEqual(null, tituloSalvo, JogoEscopo._notificacoes);
        }

        [TestMethod]
        [TestCategory("Jogo")]
        public void Deve_Atualizar_Jogo()
        {         
            InicializaConexao();       

            //Busca um jogo que foi cadastrado pelo test unitário
            var entidade = (_service.Get() as IQueryable<Jogo>).ToList().Where(x=> x.Descricao.Contains("TEST")).FirstOrDefault();

            if (entidade == null)
                entidade = SalvaEntidade(false);


            entidade.Descricao     = "TEST UNITARIO "+DateTime.Now;

            var entidadeAtualizada = _service.Atualiza(entidade.Id, entidade);

            TConexao.Dispose();
            Assert.AreNotEqual(null, entidadeAtualizada, JogoEscopo._notificacoes);
        }
        
        
        [TestMethod]
        [TestCategory("Jogo")]
        public void Deve_Buscar_ID()
        {         
            InicializaConexao();

            var entidade = (_service.Get() as IQueryable<Jogo>).FirstOrDefault();

            if (entidade == null)            
                entidade = SalvaEntidade(false);
            
            var result = _service.Get(entidade.Id);
            
            TConexao.Dispose();
            Assert.AreNotEqual(null, result, JogoEscopo._notificacoes);
        }

        [TestMethod]
        [TestCategory("Jogo")]
        public void Deve_Buscar()
        {         
            InicializaConexao();
 
            var titulos = (_service.Get() as IQueryable<Jogo>).ToList();

            TConexao.Dispose();
            Assert.AreNotEqual(null, titulos, JogoEscopo._notificacoes);
        }


        [TestMethod]
        [TestCategory("Jogo")]
        public void Deve_Excluir()
        {         
            InicializaConexao();
                                   
            var entidade = SalvaEntidade(false);

            var tituloExcluido = _service.Delete(entidade.Id);

            TConexao.Dispose();
            Assert.AreNotEqual(null, tituloExcluido, JogoEscopo._notificacoes);
        }

                         
    }
}